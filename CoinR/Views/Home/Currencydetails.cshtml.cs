using CoinR.Models;
using CoinR.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoinR.Views.Home;

public class Currencydetails : PageModel
{
    public static List<CryptoCurrency> cryptoCurrencies = CryptoCurrencyService.GetAll();

    public static string _currency { get; set; }

    public CryptoCurrency cryptoCurrency;
    
    public Currencydetails(string currency)
    {
        _currency = currency;
    }


    public static String getCurrencyName()
    {
       return cryptoCurrencies.Where(x => x.detailslink == _currency).Select(x => x.name).FirstOrDefault();
    }

    public static string getCurrencyLogo()
    {
       string imgpath = Path.GetFullPath(cryptoCurrencies.Where(x => x.detailslink == _currency).Select(x => x.logo.pathToImg).FirstOrDefault());
       return "";
    }

    public static string getCurrencyRating()
    {
        return cryptoCurrencies.Where(x => x.detailslink == _currency).Select(x => x.rating).FirstOrDefault().ToString();
    }

    public static String getCurrencyChart()
    {
        return (cryptoCurrencies.Where(x => x.detailslink == _currency).FirstOrDefault()).getChartString();
    }

    public static string getPredictionPrice()
    {
        //implement
        return "27€";
    }

    public static string getChartName()
    {
        return cryptoCurrencies.Where(x => x.detailslink == _currency).Select(x => x.chartname).FirstOrDefault();

    }
    
    public static String getChartString(List<String> chart)
    {
        String chartvals = "";

        for (int i = 0; i < chart.Count; i++)
        {
            if (i == 0)
            {
                chartvals += "["+chart[i]+",";
            }

            if (i == chart.Count-1)
            {
                chartvals += ""+ chart[i] + "]";
            }
            else if(i != 0 && i != chart.Count-1)
            {
                chartvals += chart[i] + ",";
            }
        }

        return chartvals;
    }

}