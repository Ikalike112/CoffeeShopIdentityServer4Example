using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CoffeeShopService : ICoffeeShopService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public CoffeeShopService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;   
        }
         
        public async Task<List<CoffeeShopModel>> List()
        {
            var coffeeShops = _dbContext.CoffeShops.ProjectTo<CoffeeShopModel>(_mapper.ConfigurationProvider).ToListAsync();
            
            return (await coffeeShops);
        }
    }
}
