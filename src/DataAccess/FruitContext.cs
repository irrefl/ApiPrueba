using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using DataAccess.Mapping;
namespace DataAccess
{
    public class FruitContext : DbContext
    {
        public FruitContext(DbContextOptions<FruitContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FruitTypeConfig());
            modelBuilder.ApplyConfiguration(new FruitConfig());
                
        }

        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<FruitType> FruitTypes { get; set; }
    }
}
