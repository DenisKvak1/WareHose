using System.Text.Json.Serialization;
using Abstract;
using System.Text.Json.Serialization;

namespace Entities;

public class WriteOff : DbEntity
{
    [JsonIgnore]
    public WareHouse? WareHouse { get; set; }
    
    public Guid WareHouseId { get; set; }
    
    [JsonIgnore]
    public ConcreteShoes? ConcreteShoes { get; set; }
    
    public Guid ConcreteShoesId { get; set; }
    
    public string Reason { get; set; }
    
    [JsonIgnore]
    public Employee? Employee { get; set; }
    
    public Guid EmployeeId { get; set; }
    
    public DateTime Timestamp { get; set; } = DateTime.Now;
}
