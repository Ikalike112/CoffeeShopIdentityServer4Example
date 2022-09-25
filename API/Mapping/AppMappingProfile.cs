using API.Models;
using AutoMapper;
using DataAccess.Entities;

namespace API.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<CoffeShop, CoffeeShopModel>();
        }
    }
}
