using System.ComponentModel.DataAnnotations;
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

    public static string getCurrenciesStringList()
    {
        List<CryptoCurrency> currenciesList = CryptoCurrencyService.GetAll();
        String valuesListString = "";
        for (int i = 0; i < currenciesList.Count; i++)
        {
            if (i == 0)
            {
                valuesListString += "[" + cryptoCurrencies[i].getChartString() + ",";
            }
            else if (i == currenciesList.Count - 1)
            {
                valuesListString += cryptoCurrencies[i].getChartString()+ "]";
            }
            else
            {
                valuesListString += cryptoCurrencies[i].getChartString() + ",";
            }
        }

        return valuesListString;
    }
    protected void Page_Load()
    {
        // cryptoCurrencies = CryptoCurrencyService.GetAll();
    }

}