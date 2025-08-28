using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext appDbContext;

        public ProductRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            appDbContext.Products.Add(product);
            await appDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return await appDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task RemoveProduct(Product product)
        {
            appDbContext.Products.Remove(product);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> SearchProducts(string searchText)
        {
            return await GetProductsFilter(searchText).ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            appDbContext.Products.Update(product);
            await appDbContext.SaveChangesAsync();
        }

        private IQueryable<Product> GetProductsFilter(string searchText)
        {
            var products = appDbContext.Products.AsNoTracking();

            if (!string.IsNullOrEmpty(searchText))
            {
                searchText = searchText.ToLower().Trim();
                products = products.Where(p => p.Name.ToLower().Contains(searchText));
            }

            return products;
        }
    }
}
