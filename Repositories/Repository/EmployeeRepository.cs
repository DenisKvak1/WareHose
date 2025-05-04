using Entities;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Repositories.Generic;

namespace Repositories.Repository;

public class EmployeeRepository : DbRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(DbContext context) : base(context)
    {
    }

    public async Task<Employee?> GetByEmailAsync(string email)
    {
        return await _context.Set<Employee>().FirstOrDefaultAsync(x => x.Email == email);
    }
}