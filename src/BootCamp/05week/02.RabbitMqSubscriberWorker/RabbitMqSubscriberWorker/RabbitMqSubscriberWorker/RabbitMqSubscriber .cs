using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMqSubscriberWorker
{
    public class RabbitMqSubscriber : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private string _consumerTag;

        private readonly ILogger<RabbitMqSubscriber> _logger;
        public RabbitMqSubscriber(ILogger<RabbitMqSubscriber> logger)
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
                channel.QueueDeclare("mesajkuyrugu3", false, false, true);
                byte[] bytemessage = Encoding.UTF8.GetBytes("sebepsiz boş yere ayrılacaksan");
                channel.BasicPublish(exchange: "", routingKey: "mesajkuyrugu3", body: bytemessage);
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
