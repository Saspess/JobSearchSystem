using Confluent.Kafka;
using Kafka.Configurations;
using Kafka.Consumer;
using Kafka.Contracts;
using Kafka.Producer;
using Kafka.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Kafka.IoC
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddKafkaConsumer<TKey, TValue, THandler>(this IServiceCollection services, Action<ConsumerKafkaConfiguration<TKey, TValue>> action) where THandler : class, IKafkaConsumerHandler<TKey, TValue>
        {
            services.AddScoped<IKafkaConsumerHandler<TKey, TValue>, THandler>();
            services.AddHostedService<KafkaConsumer<TKey, TValue>>();
            services.Configure(action);

            return services;
        }

        public static IServiceCollection AddKafkaProducer<TKey, TValue>(this IServiceCollection services, Action<ProducerKafkaConfiguration<TKey, TValue>> action)
        {
            services.AddConfluentKafkaProducer<TKey, TValue>();
            services.AddSingleton<IKafkaProducer<TKey, TValue>, KafkaProducer<TKey, TValue>>();
            services.Configure(action);

            return services;
        }

        private static IServiceCollection AddConfluentKafkaProducer<TKey, TValue>(this IServiceCollection services)
        {
            services.AddSingleton(
                sp =>
                {
                    var config = sp.GetRequiredService<IOptions<ProducerKafkaConfiguration<TKey, TValue>>>();
                    var builder = new ProducerBuilder<TKey, TValue>(config.Value).SetValueSerializer(new KafkaSerializer<TValue>());

                    return builder.Build();
                });

            return services;
        }
    }
}
