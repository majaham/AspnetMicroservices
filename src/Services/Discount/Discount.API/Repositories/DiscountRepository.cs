using Dapper;
using Npgsql;
using System;
using System.Threading.Tasks;
using Discount.API.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;
        private readonly NpgsqlConnection _connection;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            _connection = new NpgsqlConnection(_configuration.GetValue<string>("ConnectionStrings:DatabaseString"));

            //_connection.Open();

        }

        public async Task<IEnumerable<Coupon>> GetAllDiscount()
        {
            var discounts = await _connection.QueryAsync<Coupon>("SELECT * FROM Discount;");

            return discounts.ToList();
        }

        public async Task<Coupon> GetDiscount(string productname)
        {
            Coupon discount = await _connection
                .QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Discount WHERE ProductName=@productName",
                new { productName = productname });

            if (discount == null) 
                return new Coupon { ProductName = "No discount", Amount = 0, Description = "No discount description" };

            return discount;
        }

        public async Task<Coupon> CreateDiscount(Coupon discount)
        {
            string cmd = "INSERT INTO Discount(ProductName, Amount, Description) VALUES(@productName, @amount,  @description)";

            await _connection.ExecuteAsync(cmd, 
                new { productName = discount.ProductName, amount = discount.Amount, description = discount.Description });

            return await GetDiscount(discount.ProductName);           
        }

        public async Task<Coupon> UpdateDiscount(Coupon discount)
        {
            string cmd = "UPDATE Discount SET ProductName=@productName, Amount=@amount, Description=@description WHERE Id=@Id;";

            await _connection.ExecuteAsync(cmd,
                new { productName = discount.ProductName, amount = discount.Amount, description = discount.Description, Id= discount.Id });

          return await GetDiscount(discount.ProductName);
        }

        public async Task<bool> DeleteDiscount(string productname)
        {
            string cmd = "DELETE FROM Discount WHERE ProductName=@productname;";

            int affected = await _connection.ExecuteAsync(cmd, new { productName = productname });

            if (affected > 0) return true;

            return false;
        }     
       
    }
}
