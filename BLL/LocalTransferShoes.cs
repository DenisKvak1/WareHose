using System.Linq.Expressions;
using Entities;
using Microsoft.EntityFrameworkCore;
using Migrations;
using WareHose.Common;

namespace BLL;

public class LocalTransferShoes(
    IPlacementRepository placementRepository
)
{
    public async Task Execute(Guid wareHouseId, PlacementPoint fromPlacementPoint, PlacementPoint toPlacementPoint)
    {
        Expression<Func<Placement, bool>> fromFilter = x =>
            x.WareHouseId == wareHouseId &&
            x.Row == fromPlacementPoint.Row &&
            x.Section == fromPlacementPoint.Selection &&
            x.Tier == fromPlacementPoint.Tier &&
            x.Cell == fromPlacementPoint.Cell;

        Expression<Func<Placement, bool>> toFilter = x =>
            x.WareHouseId == wareHouseId &&
            x.Row == toPlacementPoint.Row &&
            x.Section == toPlacementPoint.Selection &&
            x.Tier == toPlacementPoint.Tier &&
            x.Cell == toPlacementPoint.Cell;


        Placement? fromPlacement = await placementRepository.AllItems
            .FirstOrDefaultAsync(fromFilter);
        bool toPlacementExist = await placementRepository.AllItems
            .AnyAsync(toFilter);
        if (fromPlacement == null) throw new Exception("Invalid placement point");

        await placementRepository.AllItems
            .Where(fromFilter)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(x => x.Row, toPlacementPoint.Row)
                .SetProperty(x => x.Section, toPlacementPoint.Selection)
                .SetProperty(x => x.Tier, toPlacementPoint.Tier)
                .SetProperty(x => x.Cell, toPlacementPoint.Cell)
            );

        if (toPlacementExist)
        {
            await placementRepository.AllItems
                .Where(toFilter)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(x => x.Row, fromPlacementPoint.Row)
                    .SetProperty(x => x.Section, fromPlacementPoint.Selection)
                    .SetProperty(x => x.Tier, fromPlacementPoint.Tier)
                    .SetProperty(x => x.Cell, fromPlacementPoint.Cell)
                );
        }
    }
}