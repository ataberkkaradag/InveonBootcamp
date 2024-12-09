using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaginationExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public static List<Product> Products = new List<Product>
       {
        new Product { Id = 1, Name = "Laptop", Price = 15500 },
        new Product { Id = 2, Name = "Smartphone", Price = 11800 },
        new Product { Id = 3, Name = "Tablet", Price = 6000 },
        new Product { Id = 4, Name = "Headphones", Price = 1200 },
        new Product { Id = 5, Name = "Monitor", Price = 3000 },
         new Product { Id = 6, Name = "Mouse", Price = 15500 },
        new Product { Id = 7, Name = "Motherboard", Price = 11800 },
        new Product { Id = 8, Name = "CPU", Price = 6000 },
        new Product { Id = 9, Name = "SSD", Price = 1200 },
        new Product { Id = 10, Name = "RAM", Price = 3000 }
      };

        [HttpGet]
        public IActionResult GetPagedData(int pageNumber = 2, int pageSize = 5)

        {

            var data = Products.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToList();



            return Ok(data);

        }
    }
}
