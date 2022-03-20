using CoinR.Models;
using CoinR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoinR.Views.Home;

public class Currencydetails : PageModel
{
    public static List<CryptoCurrency> cryptoCurrencies = CryptoCurrencyService.GetAll();

    public static string _currency { get; set; }
    public Currencydetails(string currency)
    {
        _currency = currency;
    }
    
    public void OnGet([FromRoute] String currency)
    {
        Console.WriteLine(currency);
    }

    
    
    
}