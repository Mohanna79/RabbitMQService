using NationalCopyService.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace NationalCopyService.Services
{
    public class ReceiveNationalService : IReceiveNationalService
    {
        private readonly NationalService _nationalService;

        public ReceiveNationalService(NationalService nationalService)
        {
            _nationalService = nationalService;

        }
        public mw Receive()
        {
            var createdLog = new mw();
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Responce",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    var createdLog = new NationalsService
                    {
                        Message = message
                    };

                    _nationalService.Create(createdLog);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "Responce",
                                     autoAck: true,
                                     consumer: consumer);


                return createdLog;
            }
        }
    }
}
