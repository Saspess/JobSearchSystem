using Confluent.Kafka;
using Kafka.Configurations;
using Kafka.Contracts;
using Kafka.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Kafka.Consumer
{
    public class KafkaConsumer<TKey, TValue> : BackgroundService
    {
        private readonly ConsumerKafkaConfiguration<TKey, TValue> _config;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private IKafkaConsumerHandler<TKey, TValue> _handler;

        public KafkaConsumer(IOptions<ConsumerKafkaConfiguration<TKey, TValue>> config,
                             IServiceScopeFactory serviceScopeFactory)
        {
            _config = config.Value;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            _handler = scope.ServiceProvider.GetRequiredService<IKafkaConsumerHandler<TKey, TValue>>();

            var builder = new ConsumerBuilder<TKey, TValue>(_config).SetValueDeserializer(new KafkaDeserializer<TValue>());

            using var consumer = builder.Build();
            consumer.Subscribe(_config.Topic);

            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(5);
                var result = consumer.Consume(TimeSpan.FromMilliseconds(15));

                if (result != null)
                {
                    await _handler.HandleAsync(result.Message.Key, result.Message.Value);

                    consumer.Commit(result);
                    consumer.StoreOffset(result);
                }
            }
        }
    }
}
