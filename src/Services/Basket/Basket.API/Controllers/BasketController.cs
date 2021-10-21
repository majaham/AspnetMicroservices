using System;
using System.Net;
using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using EventBus.Messages.Events;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly DiscountGrpcService _discountService;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<BasketController> _logger;

        public BasketController(IBasketRepository basketRepository, DiscountGrpcService discountService, IMapper mapper, IPublishEndpoint publishEndpoint, ILogger<BasketController> logger)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _discountService = discountService ?? throw new ArgumentNullException(nameof(discountService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{username}", Name = "GetBasket")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string username)
        {
            var basket = await _basketRepository.GetBasket(username);
            if (basket == null)
            {
                _logger.LogError($"Basket for {username} not found");
                return NotFound();
            }
            return Ok(basket);
        }
        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {
            foreach(var item in basket.ShoppingCartItems)
            {
                var couponModel = await _discountService.GetDiscount(item.ProductName);
                item.Price -= couponModel.Amount;
            }
            return Ok(await _basketRepository.UpdateBasket(basket));
        }
        [HttpDelete("{username}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteBasket(string username)
        {
            await _basketRepository.DeleteBasket(username);

            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CheckoutBasket([FromBody]BasketCheckout basketCheckout)
        {
            //set basket by username
            var basket = await _basketRepository.GetBasket(basketCheckout.UserName);
            if(basket == null)
            {
                return BadRequest();
            }
            //set totalprice
            //publish event
            var eventMessage = _mapper.Map<BasketCheckoutEvent>(basket);
            await _publishEndpoint.Publish(eventMessage);
            //remove basketcheckout
            await _basketRepository.DeleteBasket(basketCheckout.UserName);

            return Accepted();
        }
    }
}
