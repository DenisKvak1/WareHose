using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkTest.domain.context.Models;

public class ConcreteShoesConfiguration : IEntityTypeConfiguration<ConcreteShoes>
{
    public void Configure(EntityTypeBuilder<ConcreteShoes> builder)
    {
        builder
            .HasOne(x => x.Shoes)
            .WithMany(x => x.ConcreteShoesList)
            .HasForeignKey(x => x.ShoesId);
    }
}