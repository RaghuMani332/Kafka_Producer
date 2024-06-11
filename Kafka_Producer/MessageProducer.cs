using Confluent.Kafka;
using Microsoft.Extensions.Configuration;

namespace Kafka_Producer
{
    public class MessageProducer
    {
        public void produceMessage()
        {
            var configuration = new ConfigurationBuilder()
                       .SetBasePath(AppContext.BaseDirectory)
                       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                       .Build();

            // Retrieve Kafka configuration
            var kafkaConfigSection = configuration.GetSection("Kafka");
            var bootstrapServers = kafkaConfigSection["BootstrapServers"];
            var topicName = kafkaConfigSection["TopicName"];

            ProducerConfig config = new ProducerConfig { BootstrapServers=bootstrapServers};
            IProducer<String,String> producer =new ProducerBuilder<String,String>(config).Build();
            try
            {
                String state;
                while((state=Console.ReadLine())!=null)
                {
                    Message<String, String> msg = new Message<string, string> { Key = "newKey", Value = state };
                    producer.Produce(topicName, msg);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
