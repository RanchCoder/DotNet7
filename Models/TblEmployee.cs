using System;
using System.Collections.Generic;

namespace DotNet7.Models
{
    public partial class TblEmployee
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Designation { get; set; }
    }
}