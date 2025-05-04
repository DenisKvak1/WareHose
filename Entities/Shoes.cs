using System.Text.Json.Serialization;
using Abstract;

namespace Entities;

public class Shoes : DbEntity
{
    public string Name { get; set; }
    public string Producer { get; set; }

    [JsonIgnore]
    public List<ConcreteShoes>? ConcreteShoesList { get; set; }
}