using CoinR.Models;
using CoinR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CoinR.Views.Home;

public class Currencydetails : PageModel
{
    public static List<CryptoCurrency> cryptoCurrencies = CryptoCurrencyService.GetAll();

    public static string _currency { get; set; }
    public static string currentDirectory { get; set; }

    public CryptoCurrency cryptoCurrency;

    public Currencydetails(string currency)
    {
        currentDirectory = this.GetType().Name;
        if (currency == null)
        {
            _currency = "Bitcoin";
        }
        else
        {
            _currency = currency;
        }
    }



    public static String getCurrencyName()
    {
        return cryptoCurrencies.Where(x => x.detailslink == _currency).Select(x => x.name).FirstOrDefault();
    }

    public static string getCurrencyLogo()
    {
        string imgpath = Path.GetRelativePath(currentDirectory,
            cryptoCurrencies.Where(x => x.detailslink == _currency).Select(x => x.logo.pathToImg).FirstOrDefault());
        return imgpath;
    }

    public static string getCurrencyRating()
    {
        return cryptoCurrencies.Where(x => x.detailslink == _currency).Select(x => x.rating).FirstOrDefault()
            .ToString();
    }

    public static String getCurrencyChart()
    {
        return (cryptoCurrencies.Where(x => x.detailslink == _currency).FirstOrDefault()).getChartString();
    }

    public static int getCurrencyChartCount()
    {
        return (cryptoCurrencies.Where(x => x.detailslink == _currency).FirstOrDefault()).chart.Count;
    }

    public static string getPredictionPrice()
    {
        //implement
        return "27€";
    }

    public static string getChartName()
    {
        return "\"" + cryptoCurrencies.Where(x => x.detailslink == _currency).Select(x => x.name).FirstOrDefault() +
               "\"";
    }
}