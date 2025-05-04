using System.Text.Json.Serialization;
using Abstract;

namespace Entities;

public class Placement : DbEntity
{
    [JsonIgnore]
    public ConcreteShoes? ConcreteShoes { get; set; }
    public Guid ConcreteShoesId { get; set; }

    [JsonIgnore]
    public WareHouse? WareHouse { get; set; }
    public Guid WareHouseId { get; set; }

    public int Row { get; set; }
    public int Section { get; set; }
    public int Tier { get; set; }
    public int Cell { get; set; }
}