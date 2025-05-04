using Entities;
using Migrations;
using WareHose.Controllers.Generic;

namespace WareHose.Controllers;

public class OutgoingInvoiceController : ReadApiController<IOutgoingInvoiceRepository, OutgoingInvoice>
{
    public OutgoingInvoiceController(IOutgoingInvoiceRepository repository) : base(repository)
    {
    }
}