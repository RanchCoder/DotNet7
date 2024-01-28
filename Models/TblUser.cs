using System;
using System.Collections.Generic;

namespace DotNet7.Models
{
    public partial class TblUser
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public required TblRole Role { get; set; }
        public int? JobId { get; set; }
    }
}