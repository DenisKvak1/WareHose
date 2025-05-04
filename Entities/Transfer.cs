using System.Text.Json.Serialization;
using Abstract;

namespace Entities;

public class Transfer : DbEntity
{
    [JsonIgnore]
    public WareHouse? FromWareHouse { get; set; }
    public Guid FromWareHouseId { get; set; }

    [JsonIgnore]
    public WareHouse? ToWareHouse { get; set; }
    public Guid ToWareHouseId { get; set; }

    [JsonIgnore]
    public ConcreteShoes? ConcreteShoes { get; set; }
    
    public int Count { get; set; }
    public Guid ConcreteShoesId { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.Now;
}