using Entities;
using Microsoft.EntityFrameworkCore;
using Migrations;

namespace BLL;

public class TakeShoes (
    IPlacementRepository placementRepository,
    IWareHouseRepository wareHouseRepository,
    IConcreteShoesRepository concreteShoesRepository)
{
    public async Task<Placement[]> Execute(Guid concreteShoesId, Guid wareHouseId, int count)
    {
        if(!await concreteShoesRepository.IsExistAsync(concreteShoesId)) throw new Exception("concreteShoes not exist");
        if(!await wareHouseRepository.IsExistAsync(wareHouseId)) throw new Exception("wareHouse not exist");
        IQueryable<Placement> placementsQuery = placementRepository.AllItems
            .Where(x => x.WareHouseId == wareHouseId && x.ConcreteShoesId == concreteShoesId)
            .Take(count);
        Placement[] placements = await placementsQuery.ToArrayAsync();
        await placementsQuery.ExecuteDeleteAsync();

        return placements;
    }
}