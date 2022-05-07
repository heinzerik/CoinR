using System.Linq;
using System.Runtime.CompilerServices;
using CoinR.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CoinR.Models;

public class chartingHelper
{
    public static async Task<List<String>> getCurrencyChart(string tablename)
    {
        var context = new UsersDbContext(new DbContextOptions<UsersDbContext>());
        SqliteConnection con = new SqliteConnection(context.getConnectionString());
        List<String> chartvals = new List<string>();
        using (SqliteCommand cmd = new SqliteCommand("select value from " + tablename + "limit 25;", con))
        {
            con.Open();
            using (SqliteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    chartvals.Add(reader.GetString(0));
                }

                reader.Close();
            }

            con.Close();
        }

        return chartvals;
    }
}