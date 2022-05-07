using System.Collections.Immutable;
using System.Configuration;
using CoinR.Controllers;
using CoinR.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SQLitePCL;


namespace CoinR.Models;

public class _userManager
{

    

    public static async Task<string> QueryData(String email)
    {

        using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
        {
            return context.Users.Where(x => x.Email == email).Select(x => x.UserName).FirstOrDefaultAsync().Result;
        }
    }

    public static async Task<string> getUserFundings(string userId)
    {
        using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
        {
            return context.fundings.Where(x => x.userId.Equals(userId)).Select(x => x.fundings).FirstOrDefault().ToString();
        }
    }

    private static DbContextOptions getDbCConstr()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfiguration configuration = builder.Build();
        String connectionStr = configuration.GetValue<String>("DefaultConnection:value");
        return SqliteDbContextOptionsBuilderExtensions.UseSqlite(new DbContextOptionsBuilder(), connectionStr).Options;
        
    }
}