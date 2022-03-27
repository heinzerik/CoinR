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

    public static string getCurrenciesChartStringList()
    {
        List<CryptoCurrency> currenciesList = CryptoCurrencyService.GetAll();
        String valuesListString = "";
        for (int i = 0; i < currenciesList.Count; i++)
        {
            if (i == 0)
            {
                valuesListString += "[" + cryptoCurrencies[i].getChartsStringPreview() + ",";
            }
            else if (i == currenciesList.Count - 1)
            {
                valuesListString += cryptoCurrencies[i].getChartsStringPreview()+ "]";
            }
            else
            {
                valuesListString += cryptoCurrencies[i].getChartsStringPreview() + ",";
            }
        }

        return valuesListString;
    }

    public static string getCurrenciesNames()
    {
        List<CryptoCurrency> currenciesList = CryptoCurrencyService.GetAll();
        String nameslistString = "";

        for (int i = 0; i < currenciesList.Count; i++)
        {
            if (i == 0)
            {
                nameslistString += "[\"" + currenciesList[i].name + "\",";
            }
            else if (i == currenciesList.Count - 1)
            {
                nameslistString += "\"" + currenciesList[i].name + "\"]";
            }
            else
            {
                nameslistString += "\"" + currenciesList[i].name + "\",";
            }
        }

        return nameslistString;
    }

    public static String generateLabels(int count)
    {
        string label = "";
        for (int i = 0; i < count; i++)
        {
            if (i == 0)
            {
                label += "["+i+",";
            }

            if (i == count-1)
            {
                label += ""+ i + "]";
            }
            else if(i != 0 && i != count-1)
            {
                label += i + ",";
            }
        }

        return label;
    }
    protected void Page_Load()
    {
        // cryptoCurrencies = CryptoCurrencyService.GetAll();
    }

}