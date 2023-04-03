namespace Kafka.Contracts
{
    public interface IKafkaProducer<TKey, TValue>
    {
        public Task ProduceAsync(TKey key, TValue value);
    }
}
