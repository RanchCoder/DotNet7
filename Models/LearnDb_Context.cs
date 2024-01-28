
using DotNet7.Models;
using Microsoft.EntityFrameworkCore;

public class LearnDb_Context : DbContext
{
    
    public LearnDb_Context(DbContextOptions<LearnDb_Context> options):base(options){
        
    }
   
   public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<TblCustomer> TblCustomers { get; set; } = null!;
        public virtual DbSet<TblDesignations> TblDesignations { get; set; } = null!;
        public virtual DbSet<TblEmployee> TblEmployees { get; set; } = null!;
        public virtual DbSet<TblMenu> TblMenus { get; set; } = null!;
        public virtual DbSet<TblPermission> TblPermissions { get; set; } = null!;
        public virtual DbSet<TblProduct> TblProducts { get; set; } = null!;
        public virtual DbSet<TblRefreshtoken> TblRefreshtokens { get; set; } = null!;
        public virtual DbSet<TblRole> TblRoles { get; set; } = null!;
        public virtual DbSet<TblUser> TblUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

}