using System;
using System.Collections.Generic;

namespace DotNet7.Models
{
    public partial class TblProduct
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string? Name { get; set; }
        public decimal? Amount { get; set; } 
    }
}