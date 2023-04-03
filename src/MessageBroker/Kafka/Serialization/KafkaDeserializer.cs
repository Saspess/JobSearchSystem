using Confluent.Kafka;
using Newtonsoft.Json;
using System.Text;

namespace Kafka.Serialization
{
    internal class KafkaDeserializer<T> : IDeserializer<T>
    {
        public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            if (typeof(T) == typeof(Null))
            {
                if (data.Length > 0)
                {
                    throw new ArgumentException("The data is not null!");
                }

                return default;
            }
            else if (typeof(T) == typeof(Ignore))
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(data));
        }
    }
}
