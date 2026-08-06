using Demo.Models;

namespace Demo.Repo;

public class ProductRepository : IProductRepository
{
    // list to store products for the demo
    private readonly List<Product> _products = new List<Product>();

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public void Add(Product product)
    {
        _products.Add(product);
    }
}
