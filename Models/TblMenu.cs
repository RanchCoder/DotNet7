using System;
using System.Collections.Generic;

namespace DotNet7.Models
{
    public partial class TblMenu
    {
        
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? LinkName { get; set; }
    }
}