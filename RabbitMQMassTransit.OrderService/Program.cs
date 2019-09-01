using MassTransit;
using RabbitMQMassTransit.Common;
using System;

namespace RabbitMQMassTransit.OrderService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "OrderService";

            var bus = BusConfigurator.BusConfiguratorInstance
                .ConfigureBus((cfg, host) =>
                {
                    cfg.ReceiveEndpoint(host, "rabbitmqmasstransit.order", e =>
                    {
                        e.Consumer<OrderCommandConsumer>();
                    });
                });

            bus.Start();
            Console.WriteLine("Listening order command..");
            Console.ReadLine();
        }
    }
}
