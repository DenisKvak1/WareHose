using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WareHose.DTO;

namespace WareHose.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TransferController : ControllerBase
{
    private TransferShoes _transferShoes;
    private LocalTransferShoes _transferShoesLocal;

    public TransferController(TransferShoes transferShoes, LocalTransferShoes transferShoesLocal)
    {
        _transferShoes = transferShoes;
        _transferShoesLocal = transferShoesLocal;
    }
    
    [HttpPost("transfer")]
    public async Task<IActionResult> TransferShoes([FromBody] TransferShoesDto dto)
    {
       var placements = await _transferShoes.Execute(dto.FromWarehouseId, dto.ToWarehouseId, dto.ConcreteShoesId, dto.Count);
       return Ok(placements);
    }
    
    [HttpPost("localTransfer")]
    public async Task<IActionResult> TransferShoesLocal([FromBody] TransferShoesLocalDto dto)
    {
        await _transferShoesLocal.Execute(dto.WareHouseId, dto.FromPlacementPoint, dto.ToPlacementPoint);
        return Ok();
    }
}