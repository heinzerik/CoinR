namespace CoinR.Models;

public class CryptoCurrency
{
    public CryptoCurrency(string name, Image logo, Rating rating, string symbol, List<double> chart,String detailslink)
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

    public List<double> chart { get; set; }

    public string detailslink { get; set; }
    
    
}