using System;
using Basket.API.Entities;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task<ShoppingCart> GetBasket(string username)
        {
            string shoppingCart = await _redisCache.GetStringAsync(username);

            if (string.IsNullOrEmpty(shoppingCart))
                return null;
            
            return JsonSerializer.Deserialize<ShoppingCart>(shoppingCart);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            string _shoppingCart = JsonSerializer.Serialize(basket);
            await _redisCache.SetStringAsync(basket.Username, _shoppingCart);

            return await GetBasket(basket.Username);
        }

        public async Task DeleteBasket(string username)
        {
            await _redisCache.RemoveAsync(username);
        }
    }
}
