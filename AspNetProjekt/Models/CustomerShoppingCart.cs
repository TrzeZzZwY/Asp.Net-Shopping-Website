﻿using System.ComponentModel.DataAnnotations;

namespace AspNetProjekt.Models
{
    public class CustomerShoppingCart
    {
        [Key]
        public Guid CustomerId;
        public Customer? Customer;
        public List<Item>? Items;
    }
}