using System;
using System.Collections.Generic;

namespace DotNet7.Models
{
    public partial class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
    }
}