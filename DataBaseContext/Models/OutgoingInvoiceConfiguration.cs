using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkTest.domain.context.Models;

public class OutgoingInvoiceConfiguration : IEntityTypeConfiguration<OutgoingInvoice>
{
    public void Configure(EntityTypeBuilder<OutgoingInvoice> builder)
    {
        builder
            .HasOne(x => x.ConcreteShoes)
            .WithMany(x => x.OutgoingInvoices)
            .HasForeignKey(x => x.ConcreteShoesId);
        
        builder
            .HasOne(x=>x.WareHouse)
            .WithMany(x=>x.OutgoingInvoices)
            .HasForeignKey(x=>x.WareHouseId);
        
        builder
            .HasOne(x=>x.Employee)
            .WithMany(x=>x.OutgoingInvoices)
            .HasForeignKey(x=>x.EmployeeId);
    }
}