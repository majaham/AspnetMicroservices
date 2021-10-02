using Catalog.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetProductById(string productId);

        Task<IEnumerable<Product>> GetProductByCategory(string productCategory);

        Task<IEnumerable<Product>> GetProductByName(string productName);

        Task AddProduct(Product product);

        Task<bool> UpdateProduct(Product product);

        Task<bool> DeleteProduct(string productId);
    }
}
