using BLL;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Migrations;
using WareHose.Controllers.Generic;
using WareHose.DTO;

namespace WareHose.Controllers;

public class IncomingInvoiceController : ReadApiController<IIncomingInvoiceRepository, IncomingInvoice>
{
    public IncomingInvoiceController(IIncomingInvoiceRepository repository) : base(repository)
    {
    }
}