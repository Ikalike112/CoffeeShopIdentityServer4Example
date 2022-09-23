using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeShopController : ControllerBase
    {
        private readonly ICoffeShopService coffeShopService;
        public CoffeShopController(ICoffeShopService coffeShopService)
        {
            this.coffeShopService = coffeShopService;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var coffeshops = coffeShopService.List();
            return Ok(await coffeshops);
        }
    }
}
