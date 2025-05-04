using Entities;
using Migrations;

namespace WareHose.Controllers;

public class ShoesController : CrudApiController<IShoesRepository, Shoes>
{
    public ShoesController(IShoesRepository repository) : base(repository)
    {
    }
}