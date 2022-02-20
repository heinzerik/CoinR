using CoinR.Models;
using CoinR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoinR.Views.Home;

public class Home : PageModel
{

    public List<CryptoCurrency> cryptoCurrencies = new List<CryptoCurrency>();

    public CryptoCurrency newCryptoCurrency { get; set; } = new();
    public void OnGet()
    {
        cryptoCurrencies = CryptoCurrencyService.GetAll();
    }
}