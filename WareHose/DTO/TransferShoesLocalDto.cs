using System.ComponentModel.DataAnnotations;
using BLL;
using WareHose.Common;

namespace WareHose.DTO;

public record TransferShoesLocalDto
{
    [Required]
    public Guid WareHouseId { get; set; }

    [Required]
    public PlacementPoint FromPlacementPoint { get; set; }

    [Required]
    public PlacementPoint ToPlacementPoint { get; set; }
}