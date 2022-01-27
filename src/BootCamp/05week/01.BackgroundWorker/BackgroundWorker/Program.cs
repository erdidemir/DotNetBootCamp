using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMqConsumerWorker;
using RabbitMqSubscriberWorker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackgroundWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    //services.AddHostedService<Worker>();
                    //services.AddHostedService<TimerWorkerService>();
                    services.AddHostedService<RabbitMqSubscriber>();
                    services.AddHostedService<RabbitMqConsumer>();
                    


                });
    }
}
