using Abstract;
using Entities;

namespace Migrations;

public interface IConcreteShoesRepository : IDbRepository<ConcreteShoes>
{
    Task<int> CalculateAvailability(Guid id);
    Task<int> CalculateAvailability(Guid shoesId, Guid wareHouseId);
}