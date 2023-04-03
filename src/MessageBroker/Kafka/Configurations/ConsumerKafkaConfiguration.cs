using Confluent.Kafka;

namespace Kafka.Configurations
{
    public class ConsumerKafkaConfiguration<TKey, TValue> : ConsumerConfig
    {
        public string Topic { get; set; }

        public ConsumerKafkaConfiguration()
        {
            AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
            EnableAutoOffsetStore = false;
        }
    }
}
