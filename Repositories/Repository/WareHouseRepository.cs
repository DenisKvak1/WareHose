using Entities;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Repositories.Generic;

namespace Repositories.Repository;

public class WareHouseRepository : DbRepository<WareHouse>, IWareHouseRepository
{
    public WareHouseRepository(DbContext context) : base(context)
    {
    }
}