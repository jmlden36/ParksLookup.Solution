using Microsoft.EntityFrameworkCore;

namespace ParksLookup.Models
{
  public class ParksLookupContext : DbContext
  {
    public ParksLookupContext(DbContextOptions<ParksLookupContext> options)
        : base(options)
        {
          
        }

        public DbSet<Park> Parks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
          .HasData(
              new Park { ParkId = 1, NatOrState = "National", Name = "Yellowstone", State = "Wyoming", Rating = 10 },
              new Park { ParkId = 2, NatOrState = "National", Name = "Zion", State = "Utah", Rating = 9 },
              new Park { ParkId = 3, NatOrState = "State", Name = "Barr Lake State Park", State = "Colorado", Rating = 9 },
              new Park { ParkId = 4, NatOrState = "State", Name = "Rock Bridge State Park", State = "Missouri", Rating = 8 }
          );
    }
  }
}