using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkTest.domain.context.Models;

public class IncomingInvoiceConfiguration : IEntityTypeConfiguration<IncomingInvoice>
{
    public void Configure(EntityTypeBuilder<IncomingInvoice> builder)
    {
        builder
            .HasOne(x => x.ConcreteShoes)
            .WithMany(x => x.IncomingInvoices)
            .HasForeignKey(x => x.ConcreteShoesId);
        
        builder
            .HasOne(x=>x.WareHouse)
            .WithMany(x=>x.IncomingInvoices)
            .HasForeignKey(x=>x.WareHouseId);
        
        builder
            .HasOne(x=>x.Employee)
            .WithMany(x=>x.IncomingInvoices)
            .HasForeignKey(x=>x.EmployeeId);
    }
}