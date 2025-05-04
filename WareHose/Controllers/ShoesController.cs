using Entities;
using Migrations;

namespace WareHose.Controllers;

public class ShoesController : ApiController<IShoesRepository, Shoes>
{
    public ShoesController(IShoesRepository repository) : base(repository)
    {
    }
}