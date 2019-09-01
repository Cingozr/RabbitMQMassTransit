using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using MassTransit.RabbitMqTransport;

namespace RabbitMQMassTransit.Common
{
    public class BusConfigurator
    {
        private static readonly Lazy<BusConfigurator> _busConfiguratorInstance = new Lazy<BusConfigurator>(() => new BusConfigurator());

        private BusConfigurator(){}

        public static BusConfigurator BusConfiguratorInstance => _busConfiguratorInstance.Value;

        public IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(MQConstant.RabbitMQUri), hst =>
                {
                    hst.Username(MQConstant.RabbitMQUserName);
                    hst.Password(MQConstant.RabbitMQPassword);
                });
                registrationAction?.Invoke(cfg, host);
            });
        }
    }
}
