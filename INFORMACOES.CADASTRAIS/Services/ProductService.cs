using INFORMACOESCADASTRAIS.Data;
using INFORMACOESCADASTRAIS.Model;
using Newtonsoft.Json;
using ProductOwner.Microservice.Utility;
using RabbitMQ.Client;
using System.Text;

namespace INFORMACOESCADASTRAIS.Services
{
    public class ProductService
    {
        private readonly CadastroContext _dbContext;

        public ProductService(CadastroContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Cliente> SendModel(Cliente cliente)
        {
            var RabbitMQServer = "localhost";

            var _factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            //open an connection
            using (var connection = _factory.CreateConnection())

            //create a channel
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: StaticConfigurationManager.AppSetting["RabbitMqSettings:QueueName"], //queue name
                                     durable: true,      //remains active when restarted server
                                     exclusive: false,    //only access on actual connection
                                     autoDelete: false,   //automatic deleted when consumers get message
                                     arguments: null);    //some arguments

                var stringFieldMessage = JsonConvert.SerializeObject(cliente);

                var bodyMessage = Encoding.UTF8.GetBytes(stringFieldMessage);

                channel.BasicPublish(exchange: StaticConfigurationManager.AppSetting["RabbitMqSettings:ExchangeName"],
                                     routingKey: StaticConfigurationManager.AppSetting["RabbitMqSettings:RouteKey"],
                                     basicProperties: null,
                                     body: bodyMessage);

                return Task.FromResult(cliente);
            }
        }
    }
}




