using CoinR.Models;
using CoinR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoinR.Views.Home;

public class Home : PageModel
{

    public static List<CryptoCurrency> cryptoCurrencies = CryptoCurrencyService.GetAll();

    public void OnGet()
    {
        // CryptoCurrencyService.GetAll();
        
        
    }

    protected void Page_Load()
    {
        // cryptoCurrencies = CryptoCurrencyService.GetAll();
    }
}