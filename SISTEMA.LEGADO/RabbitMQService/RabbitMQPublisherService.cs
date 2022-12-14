using Newtonsoft.Json;
using ProductUser.Microservice.Utility;
using RabbitMQ.Client;
using System.Text;

namespace SISTEMALEGADO.RabbitMQService
{
    public class RabbitMQPublisherService<T> where T : class
    {
        public Task<T> SendModel(T modelo)
        {
            var _factory = new ConnectionFactory()
            {
                HostName = StaticConfigurationManager.AppSetting["RabbitMqSettings:Host"]
            };

            using (var connection = _factory.CreateConnection())

            using (var channel = connection.CreateModel())
            {
                //DECLARA O EXCHANGE A SER CRIADO
                channel.ExchangeDeclare(StaticConfigurationManager.AppSetting["RabbitMqSettings:ExchangeName"], StaticConfigurationManager.AppSetting["RabbitMqSettings:ExchhangeType"]);

                channel.QueueDeclare(queue: StaticConfigurationManager.AppSetting["RabbitMqSettings:QueueName"],
                                     durable: true,      //remains active when restarted server
                                     exclusive: false,    //only access on actual connection
                                     autoDelete: false,   //automatic deleted when consumers get message
                                     arguments: null);    //some arguments

                channel.QueueBind(queue: StaticConfigurationManager.AppSetting["RabbitMqSettings:QueueInformacoesCadastrais"], exchange: StaticConfigurationManager.AppSetting["RabbitMqSettings:ExchangeName"], routingKey: StaticConfigurationManager.AppSetting["RabbitMqSettings:RouteKey"]);

                var stringFieldMessage = JsonConvert.SerializeObject(modelo);

                var bodyMessage = Encoding.UTF8.GetBytes(stringFieldMessage);

                //SALVA
                var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;

                channel.BasicPublish(exchange: StaticConfigurationManager.AppSetting["RabbitMqSettings:ExchangeName"],
                                     routingKey: StaticConfigurationManager.AppSetting["RabbitMqSettings:RouteKey"],
                                     basicProperties: null,
                                     body: bodyMessage);

                return Task.FromResult(modelo);
            }
        }
    }
}




