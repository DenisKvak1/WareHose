using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace EntityFrameworkTest.domain.context;

public partial class AppDbContext : DbContext
{
   public DbSet<ConcreteShoes> ConcreteShoes { get; set; }
   public DbSet<Employee> Employees { get; set; }
   public DbSet<IncomingInvoice> IncomingInvoices { get; set; }
   public DbSet<OutgoingInvoice> OutgoingInvoices { get; set; }
   public DbSet<Placement> Placements { get; set; }
   public DbSet<Shoes> Shoes { get; set; }
   public DbSet<Transfer> Transfers { get; set; }
   public DbSet<WareHouse> WareHouses { get; set; }
   public DbSet<WriteOff> WriteOffs { get; set; }
}
