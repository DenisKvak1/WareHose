using BLL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Migrations;
using WareHose.DTO;

namespace WareHose.Controllers;

public class ConcreteShoesController : ApiController<IConcreteShoesRepository, ConcreteShoes>
{
    private GetShoesPlacement _getShoesPlacement;

    public ConcreteShoesController(GetShoesPlacement getShoesPlacement, IConcreteShoesRepository repository) :
        base(repository)
    {
        _getShoesPlacement = getShoesPlacement;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> Availability([FromQuery] GetShoesListDto dto)
    {
        ConcreteShoes[] concreteShoesArray = await _repository.AllItems.ToArrayAsync();
        var ShoesWithAvalibilty = concreteShoesArray.Select(async x =>
        {
            int availability;
            Placement[] placements = [];
            if (dto.WarehouseId == null)
            {
                availability = await _repository.CalculateAvailability(x.Id);
            }
            else
            {
                availability = await _repository.CalculateAvailability(x.Id, (Guid)dto.WarehouseId);
                if (dto.WithPlacements) placements = await _getShoesPlacement.Execute(x.Id, (Guid)dto.WarehouseId);
            }


            return new
            {
                Shoes = x,
                Availability = availability,
                Placements = placements
            };
        });

        return Ok(ShoesWithAvalibilty);
    }
}