using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using ProjetoSeguroGarantia.Infra.Messages.Models;
using ProjetoSeguroGarantia.Infra.Messages.Services;
using ProjetoSeguroGarantia.Infra.Messages.Settings;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ProjetoSeguroGarantia.Infra.Messages.Consumers
{
    public class MessageConsumer : BackgroundService
    {
        private readonly RabbitMQSettings _rabbitMQSettings;
        private readonly EmailService _emailService;

        public MessageConsumer(RabbitMQSettings rabbitMQSettings, EmailService emailService)
        {
            _rabbitMQSettings = rabbitMQSettings;
            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(_rabbitMQSettings.Url)
            };

            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();
            model.QueueDeclare(
                queue: _rabbitMQSettings.Queue,
                durable: true,
                autoDelete: false,
                exclusive: false,
                arguments: null
            );

            var consumer = new EventingBasicConsumer(model);
            consumer.Received += (sender, args) =>
            {
                //ler a mensagem contida na fila
                var body = Encoding.UTF8.GetString(args.Body.ToArray());

                //deserializando a mensagem (JSON)
                var message = JsonConvert.DeserializeObject<EmailMessageModel>(body);

                //disparando o email..
                _emailService.SendMail(message);

                //retirar a mensagem da fila
                model.BasicAck(args.DeliveryTag, false);
            };

            //executando o consumer:
            model.BasicConsume(_rabbitMQSettings.Queue, false, consumer);
        }
    }
}
