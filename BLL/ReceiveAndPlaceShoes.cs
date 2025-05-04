using Entities;
using Migrations;

namespace BLL;

public class ReceiveAndPlaceShoes(
    PlaceShoes placeShoes,
    IIncomingInvoiceRepository incomingInvoiceRepository
)
{
    public async Task<Placement[]> Execute(Guid concreteShoesId, Guid wareHouseId, Guid employeeId, int price, int count)
    {
        Placement[] placements = await placeShoes.Execute(concreteShoesId, wareHouseId, count);
        await incomingInvoiceRepository.AddItemAsync(new IncomingInvoice
        {
            WareHouseId = wareHouseId,
            EmployeeId = employeeId,
            ConcreteShoesId = concreteShoesId,
            Price = price,
            Count = count
        });
        return placements;
    }
}