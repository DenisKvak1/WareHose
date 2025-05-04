using Abstract;
using Entities;

namespace Migrations;

public interface IEmployeeRepository : IDbRepository<Employee>
{
    Task<Employee?> GetByEmailAsync(string email);
}