using Demo.Models;
using Demo.Repo;

namespace Demo.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _repository.GetAll();
    }

    public void CreateProduct(Product product)
    {
        //basic validation
        if (string.IsNullOrWhiteSpace(product.Name))
        {
            throw new ArgumentException("Product name is required.");
        }
        
        if (product.Price <= 0)
        {
            throw new ArgumentException("Price must be greater than zero.");
        }

        _repository.Add(product);
    }
}
