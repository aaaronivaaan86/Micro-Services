using Microsoft.Extensions.Configuration;
using PlatformService.Data.enums;
using PlatformService.Dtos;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlatformService.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration configuration;
        private readonly IConnection connection;
        private readonly IModel channel;

        public MessageBusClient(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = this.configuration[RabbitMqEnum.RabbitMQHost],
                Port = int.Parse(this.configuration[RabbitMqEnum.RabbitMQPort])
            };

            try
            {
                this.connection = factory.CreateConnection();
                this.channel = connection.CreateModel();
                this.channel.ExchangeDeclare(RabbitMqEnum.TriggerExchange, type: ExchangeType.Fanout);
                this.connection.ConnectionShutdown += RabbitMQConnectionShutDown;
                Console.WriteLine("---> Connected to RabbitMQ");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not connect with message bus {ex.Message}");
            }
        }

        public void PublishNewPlatform(PlatformPublishedDto platformPublishedDto)
        {
            var message = JsonSerializer.Serialize(platformPublishedDto);
            if (this.connection.IsOpen)
            {
                Console.WriteLine("--> RabbitMQ connection open. Sending message");

            }
            else
            {
                Console.WriteLine("--> RabbitMQ connection close");
            }

        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            this.channel.BasicPublish(RabbitMqEnum.TriggerExchange,
                routingKey: "",
                basicProperties: null,
                body: body);
            Console.WriteLine($"---> We have sent {message}");
        }

        public void Dispose()
        {
            if (this.channel.IsOpen)
            {
                this.channel.Close();
                this.connection.Close();
                
            }
        }



        private void RabbitMQConnectionShutDown(object sender, ShutdownEventArgs args)
        {
            Console.WriteLine("---> RabbitMq Connection Shut Down");
        }



    }
}
