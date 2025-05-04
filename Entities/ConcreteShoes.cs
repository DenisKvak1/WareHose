using System.Text.Json.Serialization;
using Abstract;

namespace Entities;

public class ConcreteShoes : DbEntity
{
    [JsonIgnore]
    public Shoes? Shoes { get; set; }
    public Guid ShoesId { get; set; }
    
    public int Size { get; set; }
    public string Color { get; set; }
    public string Article { get; set; }

    [JsonIgnore]
    public List<Placement>? Placement { get; set; }

    [JsonIgnore]
    public List<IncomingInvoice>? IncomingInvoices { get; set; }

    [JsonIgnore]
    public List<OutgoingInvoice>? OutgoingInvoices { get; set; }

    [JsonIgnore]
    public List<Transfer>? Transfers { get; set; }
}