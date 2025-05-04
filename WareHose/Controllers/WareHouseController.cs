using Abstract;
using BLL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Migrations;
using WareHose.DTO;

namespace WareHose.Controllers;

public class WareHouseController : ApiController<IWareHouseRepository, WareHouse>
{
    private ReceiveAndPlaceShoes _receiveAndPlaceShoes;
    private SellAndTakeShoes _sellAndTakeShoes;
    private GetShoesPlacement _getShoesPlacement;
    private WriteOffShoes _writeOffShoes;
    
    public WareHouseController(
        IWareHouseRepository repository,
        ReceiveAndPlaceShoes receiveAndPlaceShoes,
        SellAndTakeShoes sellAndTakeShoes,
        GetShoesPlacement getShoesPlacement,
        WriteOffShoes writeOffShoes
    ) :
        base(repository)
    {
        _receiveAndPlaceShoes = receiveAndPlaceShoes;
        _sellAndTakeShoes = sellAndTakeShoes;
        _getShoesPlacement = getShoesPlacement;
        _writeOffShoes = writeOffShoes;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RegisterReceiveGoods(RegisterReceiveGoodsDto dto)
    {
        Guid employeeId = Guid.Parse(User.FindFirst("employeeId")?.Value);
        return Ok(
            await _receiveAndPlaceShoes.Execute(
                dto.ConcreteShoesId,
                dto.WareHouseId,
                employeeId,
                dto.Price,
                dto.Count
            )
        );
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> RegisterSellGoods(RegisterSellDto dto)
    {
        Guid employeeId = Guid.Parse(User.FindFirst("employeeId")?.Value);

        return Ok(
            await _sellAndTakeShoes.Execute(
                dto.ConcreteShoesId,
                dto.WareHouseId,
                employeeId,
                dto.Price,
                dto.Count
            )
        );
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> GetShoesPlacement(GetShoesPlacementDto dto)
    {
        return Ok(
            await _getShoesPlacement.Execute(
                dto.ConcreteShoesId,
                dto.WareHouseId,
                dto.Count
            )
        );
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> WriteOff(WriteOffDto dto)
    {
        Guid employeeId = Guid.Parse(User.FindFirst("employeeId")?.Value);

        await _writeOffShoes.Execute(
            dto.WareHouseId,
            employeeId,
            dto.Reason,
            dto.PlacementPoint
        );
        return Ok();
    }
}