using CoinR.Models;
using CoinR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Data;
using System.Text;
using System.Data.SqlClient;


namespace CoinR.Views.Home;

public class Home : PageModel
{

    public static List<CryptoCurrency> cryptoCurrencies = CryptoCurrencyService.GetAll();

    public void OnGet()
    {
        // CryptoCurrencyService.GetAll();
        
        
    }

    protected void OpenPage_Click(object sender,EventArgs e)
    {
        
        Response.Redirect("http://www.google.com");
    }

    protected void Page_Load()
    {
        // cryptoCurrencies = CryptoCurrencyService.GetAll();
    }
}