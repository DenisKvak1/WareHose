using Entities;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Repositories.Generic;

namespace Repositories.Repository;

public class IncomingInvoiceRepository : DbRepository<IncomingInvoice>, IIncomingInvoiceRepository
{
    public IncomingInvoiceRepository(DbContext context) : base(context)
    {
    }
}