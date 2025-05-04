using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkTest.domain.context.Models;

public class ShoesConfiguration : IEntityTypeConfiguration<Shoes>
{
    public void Configure(EntityTypeBuilder<Shoes> builder)
    {
        
    }
}