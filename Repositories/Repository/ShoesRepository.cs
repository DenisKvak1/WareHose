using Entities;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Repositories.Generic;

namespace Repositories.Repository;

public class ShoesRepository : DbRepository<Shoes>, IShoesRepository
{
    public ShoesRepository(DbContext context) : base(context)
    {
    }
}