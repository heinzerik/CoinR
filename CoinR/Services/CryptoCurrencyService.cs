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
            new CryptoCurrency {chart=new List<double>(),logo = new Image("img/btc.png"),name = "Bitcoin",rating = Rating.buy, symbol = "BTC"},
            new CryptoCurrency {chart=new List<double>(),logo = new Image("img/eth.png"),name = "Ethereum",rating = Rating.buy, symbol = "ETH"},
            new CryptoCurrency {chart=new List<double>(),logo = new Image("img/ltc.png"),name = "Litecoin",rating = Rating.buy, symbol = "LTC"},
        };
    }

    public static List<CryptoCurrency> GetAll() => cryptoCurrencies;

    public static CryptoCurrency? Get(int id) => cryptoCurrencies.FirstOrDefault(p => p.symbol == p.symbol);

   }