using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoinR.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Fundings> fundings { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
}

public class Fundings
{
    public int id { get; set; }

    public int userId { get; set; }

    public int fundings { get; set; }
}