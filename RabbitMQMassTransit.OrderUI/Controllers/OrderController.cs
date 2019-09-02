using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MassTransit;
using Microsoft.Extensions.Configuration;
using RabbitMQMassTransit.Common;
using RabbitMQMassTransit.OrderUI.Models;
using System.Configuration;
using RabbitMQMassTransit.Messaging;

namespace RabbitMQMassTransit.OrderUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly ISendEndpoint _bus;
        public OrderController()
        {
            var rabbitMqUri = $"rabbitmq://localhost:8081/rabbitmqmasstransit.order";
            var busControl = BusConfigurator.BusConfiguratorInstance.ConfigureBus();
            var sendToUri = new Uri(rabbitMqUri);
            _bus = busControl.GetSendEndpoint(sendToUri).Result;
        }

        public IActionResult Index(OrderModel orderModel)
        {
            if (orderModel.OrderId > 0)
                CreateOrder(orderModel);
            return View();
        }

        private void CreateOrder(OrderModel orderModel)
        {
            _bus.Send(orderModel).Wait();

            //_bus.Send<IOrderCommand>(new
            //{
            //    OrderId = orderModel.OrderId,
            //    OrderCode = orderModel.OrderCode
            //});
        }
    }
}