using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoinR.Areas.Identity.Pages.Account.Manage;

public class Account : PageModel
{
    public String account = "";
    public static String? currencyselectValue = "Bitcoin";


    public static readonly List<SelectListItem> watchlist = new List<SelectListItem>()
    {
        new SelectListItem("Bitcoin", "BITCOIN", true),
        new SelectListItem("Ethereum", "ETHEREUM", false),
    };

    public static readonly List<SelectListItem> currencies = new List<SelectListItem>()
    {
        new SelectListItem("Bitcoin", "BITCOIN", true),
        new SelectListItem("Ethereum", "ETHEREUM", false),
        new SelectListItem("Litecoin", "LITECOIN", false),
    };
    
    public void OnGet()
    {
    }
}