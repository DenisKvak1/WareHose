namespace WareHose.DTO;

public record GetShoesListDto
{
    public Guid? WarehouseId { get; set; }
    public bool WithPlacements { get; set; }
}
