using Demo.Models;

namespace Demo.Repo;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();
    void Add(Product product);
}
