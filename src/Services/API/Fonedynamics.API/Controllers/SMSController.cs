using Fonedynamics.API.Services.SMSService;
using Microsoft.AspNetCore.Mvc;
using Shared.Data.DTOs;

namespace Fonedynamics.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private ISMSService smsService;

        public SMSController(ISMSService smsService)
        {
            this.smsService = smsService;
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody] SMSDto sms)
        {
            smsService.SendSMS(sms);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSMSes()
        {
            var smses = await smsService.GetSMSes();
            return Ok(smses);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetSMSById(Guid id)
        {
            var sms = await smsService.GetSMSById(id);
            return Ok(sms);
        }
    }
}