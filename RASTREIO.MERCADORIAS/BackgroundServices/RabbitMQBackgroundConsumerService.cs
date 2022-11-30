using RASTREIOMERCADORIAS.Services;
using Newtonsoft.Json;
using ProductOwner.Microservice.Utility;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RASTREIOMERCADORIAS.BackgroundServices
{
    public class RabbitMQBackgroundConsumerService<T> : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public RabbitMQBackgroundConsumerService(IServiceProvider serviceProvider)
        {
            InitRabbitMQ();
            _serviceProvider = serviceProvider;
        }

        private void InitRabbitMQ()
        {
            var _factory = new ConnectionFactory()
            {
                HostName = StaticConfigurationManager.AppSetting["RabbitMqSettings:Host"]
            };

            _connection = _factory.CreateConnection();

            _channel = _connection.CreateModel();

            //Declare Queue with Name and a few property related to Queue like durabality of msg, auto delete and many more
            _channel.QueueDeclare(queue: StaticConfigurationManager.AppSetting["RabbitMqSettings:QueueName"], //queue name
                                    durable: true,      //remains active when restarted server ******
                                    exclusive: false,    //only access on actual connection
                                    autoDelete: false,   //automatic deleted when consumers get message
                                    arguments: null);    //some arguments
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
             {
                 var content = System.Text.Encoding.UTF8.GetString(ea.Body.ToArray());

                 var message = Encoding.UTF8.GetString(ea.Body.ToArray());

                 var data = JsonConvert.DeserializeObject<T>(message);

                 Notify(data);

                 _channel.BasicAck(ea.DeliveryTag, false);
             };

            _channel.BasicConsume(StaticConfigurationManager.AppSetting["RabbitMqSettings:QueueName"], false, consumer);

            return Task.CompletedTask;
        }
        private void Notify(T data)
        {
            var scope = _serviceProvider.CreateScope();

            var notificationServer = scope.ServiceProvider.GetRequiredService<INotificationServer<T>>();
            notificationServer.NotifyUser(data);
        }
    }
}
