using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Poker.Domain;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Poker.API.RabbitMQ
{
    public class PublishVotoMQ
    {
        private readonly IConfiguration _configuration;
        
        public PublishVotoMQ(IConfiguration configuration)
        {
            this._configuration = configuration; 
        }
        public void Publish(Voto voto)
        {
            var uri = _configuration.GetSection("AppSettings:AMQPURI").Value;
            var connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri(uri)
            };

            using (var connection = connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                        queue: "poker",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                string message = JsonConvert.SerializeObject(voto);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "AllVotes",
                                     routingKey: "poker",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
