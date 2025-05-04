using BLL;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Migrations;
using WareHose.Controllers.Generic;
using WareHose.DTO;

namespace WareHose.Controllers;


public class TransferController : ReadApiController<ITransferRepository, Transfer>
{
    private TransferShoes _transferShoes;
    private LocalTransferShoes _transferShoesLocal;

    public TransferController(TransferShoes transferShoes, LocalTransferShoes transferShoesLocal, ITransferRepository transferRepository) : base(transferRepository)
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