using AutoMapper;
using Fonedynamics.API.Models.ViewModels.SMS;
using Shared.Data.Entities;

namespace Fonedynamics.API.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SMS, SMSViewModel>();
        }
    }
}
