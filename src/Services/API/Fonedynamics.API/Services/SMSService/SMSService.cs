using AutoMapper;
using Fonedynamics.API.Models.ViewModels.SMS;
using Fonedynamics.API.Repositories.SMSRepository;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Shared.Data.Configurations;
using Shared.Data.DTOs;
using System.Text;

namespace Fonedynamics.API.Services.SMSService
{
    public class SMSService : ISMSService
    {
        private ISMSRepository smsRepository;
        private readonly IMapper mapper;

        public SMSService(ISMSRepository smsRepository, IMapper mapper)
        {
            this.smsRepository = smsRepository;
            this.mapper = mapper;
        }


        public void SendSMS(SMSDto sms)
        {
            var factory = new ConnectionFactory() { HostName = RabbitMQConfiguration.HostName };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: RabbitMQConfiguration.SMSQueue,
                               durable: false,
                               exclusive: false,
                               autoDelete: false,
                               arguments: null);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(sms));

                channel.BasicPublish(exchange: "",
                               routingKey: RabbitMQConfiguration.SMSQueue,
                               basicProperties: null,
                               body: body);
            }
        }

        public async Task<IEnumerable<SMSViewModel>> GetSMSes()
        {
            return mapper.Map<IEnumerable<SMSViewModel>>(await smsRepository.GetAllSMSes());
        }

        public async Task<SMSViewModel> GetSMSById(Guid id)
        {
            var sms = mapper.Map<SMSViewModel>(await smsRepository.GetSMSById(id));
            if (sms is null)
            {
                throw new Exception("Object not found");
            }
            return sms;
        }
    }
}