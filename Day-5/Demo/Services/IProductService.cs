using Demo.Models;

namespace Demo.Services;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts();
    void CreateProduct(Product product);
}
