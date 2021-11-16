using AspnetRunBasics.Models;
using AspnetRunBasics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace AspnetRunBasics
{
    public class CheckOutModel : PageModel
    {
        private readonly IBasketService _basketService;

        [BindProperty]
        public BasketCheckoutModel Order { get; set; } = new BasketCheckoutModel();

        public BasketModel Cart { get; set; } = new BasketModel();

        public CheckOutModel(IBasketService basketService, IOrderService orderService)
        {
            _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
        }

        public async Task<IActionResult> OnGetAsync()
        {

            Cart = await _basketService.GetBasket("jahohm");
           
            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            string username = "jahohm";
            Cart = await _basketService.GetBasket(username);
            //Order = (BasketCheckoutModel)await _orderService.GetOrdersByUsername(username);

            if (!ModelState.IsValid)
            {
                return Page();
            }
            Order.UserName = username;
            Order.TotalPrice = Cart.TotalPrice;
            await _basketService.CheckoutBasket(Order);

            Cart = new BasketModel();
            
            return RedirectToPage("Confirmation", "OrderSubmitted");
        }       
    }
}