using AutoMapper;
using VehicleMarket.Controllers.Resources;
using VehicleMarket.Models;

namespace VehicleMarket.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model, ModelResource>();
        }
    }
}
