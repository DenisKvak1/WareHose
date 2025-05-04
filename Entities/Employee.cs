using System.Text.Json.Serialization;
using Abstract;

namespace Entities;

public class Employee : DbEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    [JsonIgnore]
    public List<IncomingInvoice>? IncomingInvoices { get; set; }

    [JsonIgnore]
    public List<OutgoingInvoice>? OutgoingInvoices { get; set; }   

    [JsonIgnore]
    public List<WriteOff>? WriteOffs { get; set; }
}