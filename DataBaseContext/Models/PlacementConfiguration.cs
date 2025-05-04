using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkTest.domain.context.Models;

public class PlacementConfiguration : IEntityTypeConfiguration<Placement>
{
    public void Configure(EntityTypeBuilder<Placement> builder)
    {
        builder
            .HasOne(x => x.ConcreteShoes)
            .WithMany(x => x.Placement)
            .HasForeignKey(x => x.ConcreteShoesId);
        
        builder
            .HasOne(x=>x.WareHouse)
            .WithMany(x=>x.Placements)
            .HasForeignKey(x=>x.WareHouseId);
    }
}