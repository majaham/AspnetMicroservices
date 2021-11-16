using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRunBasics
{
    public class CartModel : PageModel
    {
        private readonly IBasketService _basketService;
        private readonly ILogger<CartModel> _logger;

        public BasketModel Cart { get; set; } = new BasketModel();

        public CartModel(IBasketService basketService, ILogger<CartModel> logger)
        {
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await _basketService.GetBasket("jahohm");

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveFromCartAsync(string cartItemId)
        {
            var basket = await _basketService.GetBasket("jahohm");
            var basketItem = basket.ShoppingCartItems.FirstOrDefault(p => p.ProductId == cartItemId);
            basket.ShoppingCartItems.Remove(basketItem);
            Cart = basket;
            await _basketService.UpdateBasket(basket);

            return RedirectToPage();
        }
    }
}