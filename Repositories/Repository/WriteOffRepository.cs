using Entities;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Repositories.Generic;

namespace Repositories.Repository;

public class WriteOffRepository : DbRepository<WriteOff>, IWriteOffRepository
{
    public WriteOffRepository(DbContext context) : base(context)
    {
    }
}