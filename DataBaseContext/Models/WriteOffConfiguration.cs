using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkTest.domain.context.Models;

public class WriteOffConfiguration : IEntityTypeConfiguration<WriteOff>
{
    public void Configure(EntityTypeBuilder<WriteOff> builder)
    {
        builder
            .HasOne(x => x.Employee)
            .WithMany(x => x.WriteOffs)
            .HasForeignKey(x => x.EmployeeId);
        
        builder
            .HasOne(x=>x.WareHouse)
            .WithMany(x=>x.WriteOffs)
            .HasForeignKey(x=>x.WareHouseId);
    }
}