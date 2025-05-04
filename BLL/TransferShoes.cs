using Entities;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Repositories.Repository;

namespace BLL;

public class TransferShoes(
    PlaceShoes placeShoes,
    TakeShoes takeShoes,
    ITransferRepository transferRepository,
    IConcreteShoesRepository concreteShoesRepository,
    IPlacementRepository placementRepository,
    IWareHouseRepository wareHouseRepository
)
{
    public async Task<FromAndToPlacementsDto> Execute(Guid fromWarehouseId, Guid toWarehouseId, Guid concreteShoesId, int count)
    {
        if(!await wareHouseRepository.IsExistAsync(fromWarehouseId)) throw new Exception("wareHouse not exist");
        if(!await wareHouseRepository.IsExistAsync(fromWarehouseId)) throw new Exception("wareHouse not exist");
        if(!await concreteShoesRepository.IsExistAsync(concreteShoesId)) throw new Exception("concreteShoes not exist");
        int existingCount = await placementRepository.AllItems
            .Where(x => x.WareHouseId == toWarehouseId)
            .CountAsync();

        if (existingCount + count > (await wareHouseRepository.GetItemAsync(toWarehouseId)).Capacity)
            throw new Exception("Too many shoes");
        
        Placement[] fromPlacements = await takeShoes.Execute(concreteShoesId, fromWarehouseId, count);
        Placement[] toPlacements = await placeShoes.Execute(concreteShoesId, toWarehouseId, count);
        
        await transferRepository.AddItemAsync(new Transfer
        {
            FromWareHouseId = fromWarehouseId,
            ToWareHouseId = toWarehouseId,
            ConcreteShoesId = concreteShoesId,
            Count = count,
        });

        return new FromAndToPlacementsDto(fromPlacements, toPlacements);
    }
    public record FromAndToPlacementsDto(Placement[] FromPlacements, Placement[] ToPlacements);
}