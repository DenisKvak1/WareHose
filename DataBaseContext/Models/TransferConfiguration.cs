using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;

namespace EntityFrameworkTest.domain.context.Models;

public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> builder)
    {
        builder
            .HasOne(x => x.FromWareHouse)
            .WithMany(x => x.FromTransfers)
            .HasForeignKey(x => x.FromWareHouseId)
            .OnDelete(DeleteBehavior.Restrict);;
        
        builder
            .HasOne(x => x.ToWareHouse)
            .WithMany(x => x.ToTransfers)
            .HasForeignKey(x => x.ToWareHouseId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder
            .HasOne(x=>x.ConcreteShoes)
            .WithMany(x=>x.Transfers)
            .HasForeignKey(x => x.ConcreteShoesId);
    }
}