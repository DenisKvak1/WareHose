using Entities;
using Migrations;

namespace BLL;

public class SellAndTakeShoes(
    TakeShoes takeShoes,
    IOutgoingInvoiceRepository outgoingInvoiceRepository
)
{
    public async Task<Placement[]> Execute(Guid concreteShoesId, Guid wareHouseId, Guid employeeId, int price,
        int count)
    {
        Placement[] placements = await takeShoes.Execute(concreteShoesId, wareHouseId, count);
        await outgoingInvoiceRepository.AddItemAsync(new OutgoingInvoice()
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