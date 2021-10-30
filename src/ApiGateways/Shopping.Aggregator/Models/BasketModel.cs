﻿using System.Collections.Generic;

namespace Shopping.Aggregator.Models
{
    public class BasketModel
    {
        public string Username { get; set; }
        public List<BasketItemExtendedModel> ShoppingCartItems { get; set; } = new List<BasketItemExtendedModel>();
        public decimal TotalPrice { get; set; }
    }
}
