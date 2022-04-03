using CoinR.Models;

namespace CoinR.Services;

public static class CryptoCurrencyService
{
    static List<CryptoCurrency> cryptoCurrencies { get; }
    static int nextId = 3;
    static CryptoCurrencyService()
    {
        cryptoCurrencies = new List<CryptoCurrency>
        {
            new CryptoCurrency {chart=new List<string>{"100","20","30","40","50","90"},logo = new Image("img/btc.png"),name = "Bitcoin",rating = Rating.buy, symbol = "BTC",detailslink = "Bitcoin",chartname = "chart"},
            new CryptoCurrency {chart=new List<string>{"20","20","30","40","30","35"},logo = new Image("img/eth.png"),name = "Ethereum",rating = Rating.sell, symbol = "ETH",detailslink ="Ethereum",chartname = "chart"},
            new CryptoCurrency {chart=new List<string>{"30","20","40","40","10","20"},logo = new Image("img/ltc.png"),name = "Litecoin",rating = Rating.outperform, symbol = "LTC",detailslink = "Litecoin",chartname = "chart"},
        };
    }

    public static List<CryptoCurrency> GetAll() => cryptoCurrencies;

    public static CryptoCurrency? Get(int id) => cryptoCurrencies.FirstOrDefault(p => p.symbol == p.symbol);

   }