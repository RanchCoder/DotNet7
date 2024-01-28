using System;
using System.Collections.Generic;

namespace DotNet7.Models
{
    public partial class TblPermission
    {
        public Guid Id {get;set;}
        public Guid RoleId { get; set; }
        public string MenuId { get; set; } = null!;
    }
}