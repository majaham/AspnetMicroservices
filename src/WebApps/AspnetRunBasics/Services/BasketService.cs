using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _client;

        public BasketService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task CheckoutBasket(BasketCheckoutModel basketCheckoutModel)
        {
            var response = await _client.PostAsJson("/Basket/CheckoutBasket", basketCheckoutModel);          
        }

        public async Task<BasketModel> GetBasket(string username)
        {
            var response = await _client.GetAsync($"/Basket/{username}");
            return await response.ReadContentAs<BasketModel>();
        }

        public async Task<BasketModel> UpdateBasket(BasketModel basketModel)
        {
            var response = await _client.PostAsJson("/Basket", basketModel);
            var updatedBasket = await response.ReadContentAs<BasketModel>();
            return updatedBasket;
        }
    }
}
