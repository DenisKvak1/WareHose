using Entities;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Repositories.Generic;

namespace Repositories.Repository;

public class OutgoingInvoiceInvoiceRepository : DbRepository<OutgoingInvoice>, IOutgoingInvoiceRepository
{
    public OutgoingInvoiceInvoiceRepository(DbContext context) : base(context)
    {
    }
}