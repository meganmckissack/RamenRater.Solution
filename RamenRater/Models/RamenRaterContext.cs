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

  }
}