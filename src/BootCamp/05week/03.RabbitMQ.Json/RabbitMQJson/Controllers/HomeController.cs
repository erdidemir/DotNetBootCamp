using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQJson.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ConnectionFactory factory;
        private readonly IConnection connection;

        public HomeController()
        {
            factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            connection = factory.CreateConnection();
        }

        [HttpGet("/")]
        public IActionResult Get()
        {
            var customer = new
            {
                Id = 1,
                Name = "customer",
                Email = "customer@customer.com"
            };

            using (var channel = this.connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: "customer",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                var customerPayload = JsonSerializer.Serialize(customer);

                var body = Encoding.UTF8.GetBytes(customerPayload);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: "customer",
                    basicProperties: null,
                    body: body
                );
            }

            return Ok(customer);
        }
    }
}
