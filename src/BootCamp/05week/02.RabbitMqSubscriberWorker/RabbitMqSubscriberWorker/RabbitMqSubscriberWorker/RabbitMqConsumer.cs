using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMqConsumerWorker
{
    public class RabbitMqConsumer : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private string _consumerTag;

        private readonly ILogger<RabbitMqConsumer> _logger;
        public RabbitMqConsumer(ILogger<RabbitMqConsumer> logger)
        {
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume("mesajkuyrugu3", false, consumer);
                consumer.Received += (sender, e) =>
                {
                    //e.Body : Kuyruktaki mesajı verir.
                    Console.WriteLine(Encoding.UTF8.GetString(e.Body.ToArray()));
                };
            }
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            //_channel.BasicCancel(_consumerTag);
            //_channel.Close();
            //_connection.Close();
            return base.StopAsync(cancellationToken);
        }
    }
}
