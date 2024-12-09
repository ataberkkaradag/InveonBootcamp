using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RedisCacheExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public ProductsController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public static List<Product> Products = new List<Product>
       {
        new Product { Id = 1, Name = "Laptop", Price = 15500 },
        new Product { Id = 2, Name = "Smartphone", Price = 11800 },
        new Product { Id = 3, Name = "Tablet", Price = 6000 },
        new Product { Id = 4, Name = "Headphones", Price = 1200 },
        new Product { Id = 5, Name = "Monitor", Price = 3000 }
      };

        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            string cacheKey = $"product:{id}";

            var cachedProduct = await _cacheService.GetAsync<Product>(cacheKey);
            if (cachedProduct != null)
            {
                return $"Veri cacheden geldi {cachedProduct.Name}";
            }

            var product = Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return "NotFound";
            }

            await _cacheService.SetAsync(cacheKey, product, TimeSpan.FromMinutes(30));
            return $"Veri db den geldi {product.Name}";


        }
    }
}
