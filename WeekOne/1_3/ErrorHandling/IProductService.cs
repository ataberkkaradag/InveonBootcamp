using ErrorHandling.Models;

namespace ErrorHandling
{
    public interface IProductService
    {
        ServiceResult<List<Product>> GetAll();
        ServiceResult<Product> GetById(int id);
        ServiceResult<Product> Create(Product product);
        ServiceResult<Product> Update(int id, Product product);
        ServiceResult<bool> Delete(int id);
    }
}
