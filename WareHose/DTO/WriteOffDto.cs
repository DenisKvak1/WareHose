using System.ComponentModel.DataAnnotations;
using BLL;
using WareHose.Common;

namespace WareHose.DTO;

public record WriteOffDto
{
    [Required]
    public Guid WareHouseId { get; set; }

    [Required]
    [MinLength(1)]
    public string Reason { get; set; }

    [Required]
    public PlacementPoint PlacementPoint { get; set; }
}