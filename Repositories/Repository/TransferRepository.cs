using Entities;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Repositories.Generic;

namespace Repositories.Repository;

public class TransferRepository : DbRepository<Transfer>, ITransferRepository
{
    public TransferRepository(DbContext context) : base(context)
    {
    }
}