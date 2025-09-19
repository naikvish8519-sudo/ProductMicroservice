using DataAccessLayer.Entities;
using eCommerce.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;





namespace eCommerce.DataAccessLayer.Context;

public class ApplicationDbContext : DbContext
{
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
  {
  }

  public DbSet<Product> Products { get; set; }
  public DbSet<PizzaSize> PizzaSizes { get; set; }
  public DbSet<Topping> Toppings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);


  }
}
