using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CoffeShopService : ICoffeShopService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public CoffeShopService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;   
        }
         
        public async Task<List<CoffeShopModel>> List()
        {
            var coffeeShops = _dbContext.CoffeShops.ProjectTo<CoffeShopModel>(_mapper.ConfigurationProvider).ToListAsync();
            
            return (await coffeeShops);
        }
    }
}
