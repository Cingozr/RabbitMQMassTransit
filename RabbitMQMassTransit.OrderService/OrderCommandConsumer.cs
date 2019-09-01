using MassTransit;
using RabbitMQMassTransit.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMassTransit.OrderService
{
    public class OrderCommandConsumer : IConsumer<IOrderCommand>
    {
        public async Task Consume(ConsumeContext<IOrderCommand> context)
        {
            var orderCommand = context.Message;
            await Console.Out.WriteAsync($"Order Code : {orderCommand.OrderCode} - Order Id : {orderCommand.OrderId}");
        }
    }
}
