using Microsoft.EntityFrameworkCore;

namespace RamenRater.Models
{
  public class RamenRaterContext : DbContext
  {
    public RamenRaterContext(DbContextOptions<RamenRaterContext> options) : base(options)
    {

    }

    public DbSet<Ramen> Ramens { get; set; } //only using ramens because of entity database naming conventions

    // protected override void OnModelCreating(DbModelBuilder modelBuilder) 
    // { 
    //   modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //Update: can't use this - overrides the need for pluralising the table name
    // } 

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Ramen>()
        .HasData(
          new Ramen { RamenId = 1, Type = "Tonkotsu", Description = "Soy base, Pork Broth, and Pork Belly", Restaurant = "Wu-Rons", Location = "Portland, OR", Rating = 5, Review = "I loved the tonkotsu broth and the pork belly."},
          new Ramen { RamenId = 2, Type = "Shoyu", Description = "Chiken and fish broth, topped with cha shu pork", Restaurant = "Hapa Ramen", Location = "Portland, OR", Rating = 5, Review = "The broth is divine"}, 
          new Ramen { RamenId = 3, Type = "Tonkotsu", Description = "spice miso tare and pork broth with ginger pork crumbles", Restaurant = "Afuri", Location = "Portland, OR", Rating = 5, Review = "Super rich and delicious"}
        );

    }
  }
}