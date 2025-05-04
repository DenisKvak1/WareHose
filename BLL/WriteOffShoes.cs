using Entities;
using Microsoft.EntityFrameworkCore;
using Migrations;
using WareHose.Common;

namespace BLL;

public class WriteOffShoes(
    IWriteOffRepository writeOffRepository,
    IEmployeeRepository employeeRepository,
    IPlacementRepository placementRepository,
    IWareHouseRepository wareHouseRepository
)
{
    public async Task Execute(Guid wareHouseId, Guid employeeId, string reason,
        PlacementPoint placementPoint)
    {
        if (!await employeeRepository.IsExistAsync(employeeId)) throw new Exception("wareHouse not exist");
        WareHouse? wareHouse = await wareHouseRepository.GetItemAsync(wareHouseId);
        if (wareHouse == null) throw new Exception("wareHouse not exist");

        if (
            placementPoint.Row > wareHouse.RowCount || placementPoint.Row < 1 ||
            placementPoint.Selection > wareHouse.SectionCount || placementPoint.Selection < 1 ||
            placementPoint.Tier > wareHouse.TierCount || placementPoint.Tier < 1 ||
            placementPoint.Cell > wareHouse.CellCount || placementPoint.Cell < 1
        )
        {
            throw new Exception("Invalid placement point");
        }

        await placementRepository.AllItems
            .Where(x =>
                x.WareHouseId == wareHouseId &&
                x.Row == placementPoint.Row &&
                x.Section == placementPoint.Selection &&
                x.Tier == placementPoint.Tier &&
                x.Cell == placementPoint.Cell
            )
            .ExecuteDeleteAsync();
        await writeOffRepository.AddItemAsync(new WriteOff
        {
            WareHouseId = wareHouseId,
            EmployeeId = employeeId,
            Reason = reason,
        });
    }
}