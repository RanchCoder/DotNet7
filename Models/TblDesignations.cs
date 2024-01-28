using System;
using System.Collections.Generic;

namespace DotNet7.Models
{
    public partial class TblDesignations
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = null!;
        public string? Name { get; set; }
    }
}