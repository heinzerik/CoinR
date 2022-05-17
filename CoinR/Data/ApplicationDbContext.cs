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
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
    }
    
    public string getConnectionString()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfiguration configuration = builder.Build();
        return configuration.GetValue<String>("ConnectionStrings:DefaultConnection:value");
    }
}

public class Fundings
{
    public int id { get; set; }

    public int userId { get; set; }

    public int fundings { get; set; }
}