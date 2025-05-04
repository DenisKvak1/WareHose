using Entities;
using Microsoft.EntityFrameworkCore;
using Migrations;

namespace BLL;

public class GetShoesPlacement(
    IPlacementRepository placementRepository,
    IWareHouseRepository wareHouseRepository,
    IConcreteShoesRepository concreteShoesRepository)
{
    public async Task<Placement[]> Execute(Guid concreteShoesId, Guid wareHouseId, int count = 0)
    {
        if (!await concreteShoesRepository.IsExistAsync(concreteShoesId))
            throw new Exception("concreteShoes not exist");
        if (!await wareHouseRepository.IsExistAsync(wareHouseId)) throw new Exception("wareHouse not exist");
        
        IQueryable<Placement> query = placementRepository.AllItems.Where(x => x.WareHouseId == wareHouseId && x.ConcreteShoesId == concreteShoesId);
        if (count != 0)
        {
            return await query
                .Take(count)
                .ToArrayAsync();
        }
        return await query.ToArrayAsync();
    }
}