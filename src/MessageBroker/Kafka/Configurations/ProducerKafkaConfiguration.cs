using Confluent.Kafka;

namespace Kafka.Configurations
{
    public class ProducerKafkaConfiguration<TKey, TValue> : ProducerConfig
    {
        public string Topic { get; set; }
    }
}
