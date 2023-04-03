using Confluent.Kafka;
using Kafka.Configurations;
using Kafka.Contracts;
using Microsoft.Extensions.Options;

namespace Kafka.Producer
{
    public class KafkaProducer<TKey, TValue> : IKafkaProducer<TKey, TValue>, IDisposable
    {
        private readonly IProducer<TKey, TValue> _producer;
        private readonly string _topic;

        public KafkaProducer(IOptions<ProducerKafkaConfiguration<TKey, TValue>> options, IProducer<TKey, TValue> producer)
        {
            _topic = options.Value.Topic;
            _producer = producer;
        }

        public async Task ProduceAsync(TKey key, TValue value)
        {
            await _producer.ProduceAsync(_topic, new Message<TKey, TValue> { Key = key, Value = value });
        }

        public void Dispose()
        {
            _producer.Dispose();
        }
    }
}