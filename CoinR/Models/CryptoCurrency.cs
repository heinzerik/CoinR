namespace CoinR.Models;

public class CryptoCurrency
{
    public CryptoCurrency(string name, Image logo, Rating rating, string symbol, List<String> chart,String detailslink)
    {
        this.name = name;
        this.logo = logo;
        this.rating = rating;
        this.symbol = symbol;
        this.chart = chart;
        this.detailslink = detailslink;
    }

    public CryptoCurrency()
    {
            
    }

    public String name { get; set; }

    public Image logo { get; set; }

    public Rating rating { get; set; }

    public String symbol { get; set; }

    public List<string> chart { get; set; }

    public string detailslink { get; set; }

    public String getChartString()
    {
        String chartvals = "";

        for (int i = 0; i < chart.Count; i++)
        {
            if (i == 0)
            {
                chartvals += "["+i+",";
            }

            if (i == chart.Count - 1)
            {
                chartvals += ""+ i + "]";
            }
            else
            {
                chartvals += i + ",";
            }
        }

        return chartvals;
    }
    
}