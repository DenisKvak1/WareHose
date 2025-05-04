using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkTest.domain.context.Models;

public class WareHouseConfiguration : IEntityTypeConfiguration<WareHouse>
{
    public void Configure(EntityTypeBuilder<WareHouse> builder)
    {
        
    }
}