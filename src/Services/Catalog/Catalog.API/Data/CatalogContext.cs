
using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly IConfiguration _config;

        public CatalogContext(IConfiguration config)
        {
            _config = config;

            string connString = _config.GetValue<string>("ConnectionStrings:ConnectionString");
            string dbname = _config.GetValue<string>("ConnectionStrings:DatabaseName");
            string colname = _config.GetValue<string>("ConnectionStrings:CollectionName");

            var client = new MongoClient(connString);
            var database = client.GetDatabase(dbname);

            Products = database.GetCollection<Product>(colname);

            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
