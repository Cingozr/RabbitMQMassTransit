using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQMassTransit.Messaging
{
    public interface IOrderCommand
    {
        int OrderId { get; set; }
        string OrderCode { get; set; }
    }
}
