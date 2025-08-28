using Domain.Entities;

namespace Application.Contracts
{
    public interface IProductRepo
    {
        Task<Product> CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task RemoveProduct(Product product);
        Task<IEnumerable<Product>> SearchProducts(string searchText);
        Task<Product> GetProductById(Guid id);
    }
}
