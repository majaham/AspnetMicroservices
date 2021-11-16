using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRunBasics.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketService _basketService;

        public IEnumerable<CatalogModel> ProductList { get; set; } = new List<CatalogModel>();

        public IndexModel(ICatalogService catalog, IBasketService basket)
        {
            _catalogService = catalog ?? throw new ArgumentNullException(nameof(catalog));
            _basketService = basket ?? throw new ArgumentNullException(nameof(basket));
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ProductList = await _catalogService.GetCatalog();
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {
            //if (!User.Identity.IsAuthenticated)
            //    return RedirectToPage("./Account/Login", new { area = "Identity" });

            var product = await _catalogService.GetCatalog(productId);

            string username = "jahohm11";
            var basket = await _basketService.GetBasket(username);
            var basketItem = new BasketItemModel 
            {
                ProductId = productId,
                ProductName = product.Name,
                Quantity = 1,
                Price = product.Price,
                Color = "Black"
            };
            basket.ShoppingCartItems.Add(basketItem);
            await _basketService.UpdateBasket(basket);

            return RedirectToPage("Cart");
        }
    }
}
