using Shared.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonedynamics.Console.Services.SMSService
{
    public interface ISMSService
    {
        Task AddSMS(SMSDto sms);
    }
}
