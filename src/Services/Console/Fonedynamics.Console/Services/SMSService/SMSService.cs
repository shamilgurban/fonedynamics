using Fonedynamics.Console.Data;
using Fonedynamics.Data.Enums;
using Shared.Data.DTOs;
using Shared.Data.Entities;

namespace Fonedynamics.Console.Services.SMSService
{
    public class SMSService : ISMSService
    {
        public async Task AddSMS(SMSDto sms)
        {
            using (var context = new PhonedynamicsContext())
            {
                foreach (var adressant in sms.To)
                {
                    await context.SMSes.AddAsync(new SMS
                    {
                        From = sms.From,
                        To = adressant,
                        Content = sms.Content,
                        Status = IsNumberValid(adressant) ? Status.Delivered : Status.Failed
                    });
                }
                await context.SaveChangesAsync();
            }
        }

        private bool IsNumberValid(string number)
        {
            // I don't know the exact validation as this didn't documented in your file so replcae it can be replaced with any condition
            return number.Length == 11;
        }
    }
}
