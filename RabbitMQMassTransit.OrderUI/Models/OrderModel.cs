using RabbitMQMassTransit.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQMassTransit.OrderUI.Models
{
    public class OrderModel : IOrderCommand
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
    }
}
