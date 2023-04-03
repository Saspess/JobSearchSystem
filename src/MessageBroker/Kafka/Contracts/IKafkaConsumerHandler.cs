namespace Kafka.Contracts
{
    public interface IKafkaConsumerHandler<TKey, TValue>
    {
        public Task HandleAsync(TKey key, TValue value);
    }
}