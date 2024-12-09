using ErrorHandling.Models;

namespace ErrorHandling
{
    public class ProductService : IProductService
    {
        public static List<Product> Products = new List<Product>
       {
        new Product { Id = 1, Name = "Laptop", Price = 15500 },
        new Product { Id = 2, Name = "Smartphone", Price = 11800 },
        new Product { Id = 3, Name = "Tablet", Price = 6000 },
        new Product { Id = 4, Name = "Headphones", Price = 1200 },
        new Product { Id = 5, Name = "Monitor", Price = 3000 }
      };

        public ServiceResult<List<Product>> GetAll()
        {
            if (Products.Any())
            {
                return ServiceResult<List<Product>>.Fail("ürün bulunamadı", 404);

            }

            return ServiceResult<List<Product>>.Success(Products, 400);
        }

        public ServiceResult<Product> GetById(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return ServiceResult<Product>.Fail("Ürün bulunamadı", 404);
            }


            return ServiceResult<Product>.Success(product, 400);
        }

        public ServiceResult<Product> Create(Product product)
        {
            if (product == null)
            {
                return ServiceResult<Product>.Fail("Ürün bilgileri geçersiz.", 400);
            }

            Products.Add(product);

            return ServiceResult<Product>.Success(product, 201);

        }

        public ServiceResult<Product> Update(int id, Product product)
        {
            var existingProduct = Products.FirstOrDefault(p => p.Id == id);

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            return ServiceResult<Product>.Success(existingProduct, 204);
        }

        public ServiceResult<bool> Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);


            Products.Remove(product);
            return ServiceResult<bool>.Success(true, 204);
        }

    }
}
