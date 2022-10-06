using Shared.Data.Entities;

namespace Fonedynamics.API.Repositories.SMSRepository
{
    public interface ISMSRepository
    {
        Task<IEnumerable<SMS>> GetAllSMSes();
        Task<SMS> GetSMSById(Guid id);
    }
}
