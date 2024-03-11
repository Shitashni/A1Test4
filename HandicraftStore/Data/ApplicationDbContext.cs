using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HandicraftStore.Models;

namespace HandicraftStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Product> Products { get; set; }  
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }


        //public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }
        //public virtual DbSet<OrderNumber> OrderNumbers { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    // Customize the ASP.NET Identity model and override the defaults if needed.
        //    // For example, you can rename the ASP.NET Identity table names and more.
        //    // Add your customizations after calling base.OnModelCreating(builder);
        //     builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        //}
    }
   
}

//internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<CraftUser>
//{
//    public void Configure(EntityTypeBuilder<CraftUser> builder)
//    {
//        builder.Property(x => x.FirstName).HasMaxLength(100);
//        builder.Property(x => x.LastName).HasMaxLength(100);
//    }
//}