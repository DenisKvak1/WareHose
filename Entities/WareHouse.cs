using System.Text.Json.Serialization;
using Abstract;

namespace Entities;

public class WareHouse : DbEntity
{
    public string Name { get; set; }
    public int RowCount { get; set; }
    public int SectionCount { get; set; }
    public int TierCount { get; set; }
    public int CellCount { get; set; }
    public int Capacity { get => RowCount * SectionCount * TierCount * CellCount; }

    [JsonIgnore]
    public List<IncomingInvoice>? IncomingInvoices { get; set; }

    [JsonIgnore]
    public List<OutgoingInvoice>? OutgoingInvoices { get; set; }

    [JsonIgnore]
    public List<Transfer>? FromTransfers { get; set; }

    [JsonIgnore]
    public List<Transfer>? ToTransfers { get; set; }

    [JsonIgnore]
    public List<Employee>? Employees { get; set; }

    [JsonIgnore]
    public List<Placement>? Placements { get; set; }

    [JsonIgnore]
    public List<WriteOff>? WriteOffs { get; set; }
}