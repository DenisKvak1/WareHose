using EntityFrameworkTest.domain.context.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkTest.domain.context;

public partial class AppDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConcreteShoesConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new IncomingInvoiceConfiguration());
        modelBuilder.ApplyConfiguration(new OutgoingInvoiceConfiguration());
        modelBuilder.ApplyConfiguration(new PlacementConfiguration());
        modelBuilder.ApplyConfiguration(new ShoesConfiguration());
        modelBuilder.ApplyConfiguration(new TransferConfiguration());
        modelBuilder.ApplyConfiguration(new WareHouseConfiguration());
        modelBuilder.ApplyConfiguration(new WriteOffConfiguration());

    }
}