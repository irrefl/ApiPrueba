using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Mapping
{
    public class FruitConfig : IEntityTypeConfiguration<Fruit>
    {
        public void Configure(EntityTypeBuilder<Fruit> fruit)
        {
            fruit.HasIndex(d => d.Id);
            fruit.HasKey(r => r.FruitId);
            fruit.Property(c => c.Name).HasMaxLength(25);
        }
    }
}
