using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext catalogContext;

        public ProductRepository(ICatalogContext context)
        {
            catalogContext = context;
        }

        public async Task AddProduct(Product product)
        {
            await catalogContext
                .Products
                .InsertOneAsync(product);
        }

       
        public async Task<IEnumerable<Product>> GetProductByCategory(string productCategory)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, productCategory);

            return await catalogContext
                .Products
                .Find(filter)
                .ToListAsync();
        }

        public async Task<Product> GetProductById(string productId)
        {
            return await catalogContext
                .Products
                .Find(p => p.Id == productId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string productName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, productName);

            return await catalogContext
                .Products
                .Find(filter)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await catalogContext
                .Products
                .Find(p => true)
                .ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await catalogContext
                .Products
                .ReplaceOneAsync(p => p.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string productId)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, productId);

            DeleteResult deleteResult = await catalogContext
                .Products
                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

    }
}
