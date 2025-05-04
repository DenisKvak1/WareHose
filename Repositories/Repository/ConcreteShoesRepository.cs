using Entities;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Repositories.Generic;

namespace Repositories.Repository;

public class ConcreteShoesRepository : DbRepository<ConcreteShoes>, IConcreteShoesRepository
{
    public ConcreteShoesRepository(DbContext context) : base(context)
    {
    }

    public async Task<int> CalculateAvailability(Guid id)
    {
        int incomingCount = await _context.Set<IncomingInvoice>()
            .Where(x => x.ConcreteShoesId == id)
            .Select(x => x.Count)
            .SumAsync();
        int outgoingCount = await _context.Set<OutgoingInvoice>()
            .Where(x => x.ConcreteShoesId == id)
            .Select(x => x.Count)
            .SumAsync();
        int writeOffCount = await _context.Set<WriteOff>()
            .Where(x => x.ConcreteShoesId == id)
            .CountAsync();

        return incomingCount - outgoingCount - writeOffCount;
    }

    public async Task<int> CalculateAvailability(Guid shoesId, Guid wareHouseId)
    {
        int incomingCount = await _context.Set<IncomingInvoice>()
            .Where(x => x.ConcreteShoesId == shoesId && x.WareHouseId == wareHouseId)
            .Select(x => x.Count)
            .SumAsync();
        int outgoingCount = await _context.Set<OutgoingInvoice>()
            .Where(x => x.ConcreteShoesId == shoesId && x.WareHouseId == wareHouseId)
            .Select(x => x.Count)
            .SumAsync();
        int incomingTransferCount = await _context.Set<Transfer>()
            .Where(x => x.FromWareHouseId == wareHouseId)
            .SumAsync(x => x.Count);
        int outgoingTransferCount = await _context.Set<Transfer>()
            .Where(x => x.FromWareHouseId == wareHouseId)
            .SumAsync(x => x.Count);
        int writeOffCount = await _context.Set<WriteOff>()
            .Where(x => x.ConcreteShoesId == shoesId)
            .CountAsync();

        return (incomingCount + incomingTransferCount) - (outgoingCount + outgoingTransferCount + writeOffCount);
    }
}