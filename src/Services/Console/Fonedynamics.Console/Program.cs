using Fonedynamics.Console.Services.SMSService;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared.Data.Configurations;
using Shared.Data.DTOs;
using System.Text;


var factory = new ConnectionFactory() { HostName = RabbitMQConfiguration.HostName };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: RabbitMQConfiguration.SMSQueue,
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += async (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        var sms = JsonConvert.DeserializeObject<SMSDto>(message);
        ISMSService smsService = new SMSService();
        await smsService.AddSMS(sms);
        sms.To.ToList().ForEach(to => Console.WriteLine(to));
    };
    channel.BasicConsume(queue: "sms_queue",
                         autoAck: true,
                         consumer: consumer);

    Console.ReadLine();
}