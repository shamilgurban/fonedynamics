using Fonedynamics.API.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Data.Entities;

namespace Fonedynamics.API.Repositories.SMSRepository
{
    public class SMSRepository : ISMSRepository
    {
        private PhonedynamicsContext phonedynamicsContext;

        public SMSRepository(PhonedynamicsContext phonedynamicsContext)
        {
            this.phonedynamicsContext = phonedynamicsContext;
        }


        public async Task<IEnumerable<SMS>> GetAllSMSes()
        {
            return await phonedynamicsContext.SMSes.ToListAsync();
        }

        public async Task<SMS> GetSMSById(Guid id)
        {
            return await phonedynamicsContext.SMSes.FirstOrDefaultAsync(sms => sms.Id == id);
        }
    }
}
