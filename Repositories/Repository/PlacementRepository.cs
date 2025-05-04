using Entities;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Repositories.Generic;

namespace Repositories.Repository;

public class PlacementRepository : DbRepository<Placement>, IPlacementRepository
{
    public PlacementRepository(DbContext context) : base(context)
    {
    }
}