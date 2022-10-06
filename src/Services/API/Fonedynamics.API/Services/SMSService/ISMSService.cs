using Fonedynamics.API.Models.ViewModels.SMS;
using Shared.Data.DTOs;
using Shared.Data.Entities;

namespace Fonedynamics.API.Services.SMSService
{
    public interface ISMSService
    {
        void SendSMS(SMSDto sms);
        Task<IEnumerable<SMSViewModel>> GetSMSes();
        Task<SMSViewModel> GetSMSById(Guid id);
    }
}
