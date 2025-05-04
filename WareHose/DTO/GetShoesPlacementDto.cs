using System.ComponentModel.DataAnnotations;

namespace WareHose.DTO;

public record GetShoesPlacementDto
{
    [Required]
    public Guid ConcreteShoesId { get; set; }

    [Required]
    public Guid WareHouseId { get; set; }

    [Range(1, int.MaxValue)]
    public int Count { get; set; } = 0;
}