using AspnetRunBasics.Models;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasket(string username);
        Task<BasketModel> UpdateBasket(BasketModel basketModel);
        Task CheckoutBasket(BasketCheckoutModel basketModel);
    }
}
