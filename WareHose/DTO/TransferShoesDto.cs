using System.ComponentModel.DataAnnotations;

namespace WareHose.DTO;

public record TransferShoesDto
{
    [Required]
    public Guid FromWarehouseId { get; set; }

    [Required]
    public Guid ToWarehouseId { get; set; }

    [Required]
    public Guid ConcreteShoesId { get; set; }

    [Range(1, int.MaxValue)]
    public int Count { get; set; }
}