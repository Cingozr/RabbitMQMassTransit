using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace RabbitMQMassTransit.Common
{
    public class MQConstant
    {
        public static string RabbitMQUri => "rabbitmq://localhost:8081/";
        public static string RabbitMQUserName => "guest";
        public static string RabbitMQPassword => "guest";
    }
}
