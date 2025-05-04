using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EntityFrameworkTest.domain.context;

public partial class AppDbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public AppDbContext()
    {

    }
}
