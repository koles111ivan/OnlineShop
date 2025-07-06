﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem>Items { get; set; }
        public decimal Cost
        {
            get
            {
                return Items.Sum(x => x.Cost);
            }
        }
    }
   
}
