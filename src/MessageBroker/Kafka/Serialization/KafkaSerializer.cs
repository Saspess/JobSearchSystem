using Confluent.Kafka;
using Newtonsoft.Json;
using System.Text;

namespace Kafka.Serialization
{
    internal class KafkaSerializer<T> : ISerializer<T>
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            if (typeof(T) == typeof(Null))
            {
                return null;
            }
            else if (typeof(T) == typeof(Ignore))
            {
                throw new NotSupportedException("Not supported!");
            }

            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
        }
    }
}
