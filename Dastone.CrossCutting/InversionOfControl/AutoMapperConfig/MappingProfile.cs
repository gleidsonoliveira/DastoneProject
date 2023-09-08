using Dastone.Domain.Entity;
using Dastone.ViewModel.Entity;

namespace Dastone.CrossCutting.InversionOfControl.AutoMapperConfig
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientViewModel>();
            CreateMap<ClientViewModel, Client>();
        }
    }
}
