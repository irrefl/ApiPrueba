using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DataAccess.Mapping
{
    public class FruitTypeConfig : IEntityTypeConfiguration<FruitType>
    {
        public void Configure(EntityTypeBuilder<FruitType> builder)
        {
            builder.HasIndex(r => r.Id);
            builder.HasKey(p => p.FruitTypeId);

            builder.HasMany(c => c.Fruits)
                .WithOne(c => c.FruitType)
            .HasForeignKey(x => x.FruitTypeId)
            .IsRequired();
        }
    }
}
