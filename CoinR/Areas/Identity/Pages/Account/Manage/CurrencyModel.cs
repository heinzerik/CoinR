using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoinR.Areas.Identity.Pages.Account.Manage;

public class CurrencyModel : PageModel
{
    public static readonly List<String> currencies = new List<string>() {"Bitcoin", "Litecoin", "Ethereum"};
}