using System.Linq;
using CoinR.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CoinR.Models;

public class chartingHelper
{
    public static async Task<String> getBitcoin()
    {
        using (var context = new UsersDbContext(new DbContextOptions<UsersDbContext>()))
        {
            return context;
        }
    }
}