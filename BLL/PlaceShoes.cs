using Entities;
using Microsoft.EntityFrameworkCore;
using Migrations;

namespace BLL;

public class PlaceShoes (
    IPlacementRepository placementRepository,
    IConcreteShoesRepository concreteShoesRepository,
    IWareHouseRepository wareHouseRepository)
{
    public async Task<Placement[]> Execute(Guid concreteShoesId, Guid wareHouseId, int count)
    {
        if(!await concreteShoesRepository.IsExistAsync(concreteShoesId)) throw new Exception("concreteShoes not exist");
        WareHouse? wareHouseEntity = await wareHouseRepository.GetItemAsync(wareHouseId);
        if (wareHouseEntity == null) throw new Exception("WareHouse not found");
        HashSet<Point4D> occupiedIndexes = new HashSet<Point4D>();
        Placement[] placements = await placementRepository.AllItems
            .Where(x => x.WareHouseId == wareHouseId)
            .ToArrayAsync();
        if (placements.Length + count > wareHouseEntity.Capacity) throw new Exception("Too many shoes");
        foreach (Placement placement in placements)
        {
            occupiedIndexes.Add(new Point4D(placement.Row, placement.Section, placement.Tier, placement.Cell));
        }
        List<Point4D> freeIndexes = new List<Point4D>();
        for (int i = 0; i < wareHouseEntity.RowCount; i++)
        {
            for (int j = 0; j < wareHouseEntity.TierCount; j++)
            {
                for (int k = 0; k < wareHouseEntity.TierCount; k++)
                {
                    for (int l = 0; l < wareHouseEntity.CellCount; l++)
                    {
                        var point = new Point4D(i, j, k, l);
                        if (!occupiedIndexes.Contains(point))
                        {
                            freeIndexes.Add(point);
                        }
                    }
                }
            }
        }
        List<Placement> newPlacements = [];
        foreach (var index in freeIndexes.Take(count))
        {
            newPlacements.Add(new Placement
            {
                ConcreteShoesId = concreteShoesId,
                WareHouseId = wareHouseId,
                Row = index.X,
                Section = index.Y,
                Tier = index.Z,
                Cell = index.W,
            });
        }
        await placementRepository.AddItemsAsync(newPlacements);

        return newPlacements.ToArray();
    }

    private record Point4D(int X, int Y, int Z, int W);
}