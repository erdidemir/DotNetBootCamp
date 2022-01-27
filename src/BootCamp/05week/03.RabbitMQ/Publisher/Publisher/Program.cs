using RabbitMQ.Client;
using System;
using System.Text;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare("iskuyrugu", durable: true, false, false, null);
                for (int i = 1; i <= 100; i++)
                {
                    byte[] bytemessage = Encoding.UTF8.GetBytes($"is - {i}");

                    IBasicProperties properties = channel.CreateBasicProperties();
                    properties.Persistent = true;

                    channel.BasicPublish(exchange: "", routingKey: "iskuyrugu", basicProperties: properties, body: bytemessage);
                }
            }
        }
    }
}
