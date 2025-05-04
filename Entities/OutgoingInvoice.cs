using System.Text.Json.Serialization;
using Abstract;

namespace Entities;
public class OutgoingInvoice : DbEntity
{
    [JsonIgnore]
    public WareHouse? WareHouse { get; set; }
    public Guid WareHouseId { get; set; }

    [JsonIgnore]
    public Employee? Employee { get; set; }
    public Guid EmployeeId { get; set; }

    [JsonIgnore]
    public ConcreteShoes? ConcreteShoes { get; set; }
    public Guid ConcreteShoesId { get; set; }

    public int Price { get; set; }
    public int Count { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
}