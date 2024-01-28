using System;
using System.Collections.Generic;

namespace DotNet7.Models
{
    public partial class TblRefreshtoken
    {
        public Guid Id {get;set;}
        public required TblUser UserId { get; set; }
        public string? TokenId { get; set; }
        public string? RefreshToken { get; set; }
        public bool? IsActive { get; set; }
    }
}