using CoinR.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoinR.Areas.Identity.Pages.Account.Manage;

public class Account : PageModel
{
    public String account = "";
    public static String? currencyselectValue = "Bitcoin";

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public string Currency { get; set; }


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


    public async Task<IActionResult> OnPostSubmit(String currency, String curr)
    {
        if (currency != null && curr == null)
        {
            if (WatchListContainsCurrency(currency.ToUpper()))
            {
                ViewData["Error"] = "Watchlist already contains currency!";
            }
            else
            {
                Account.watchlist.Add(new SelectListItem(currency, currency.ToUpper(), false));
                // return RedirectToPage("/Account/Manage/Account", new {area = "Identity"});

            }
        }
        else if (currency == null && curr != null)
        {
            if (!WatchListContainsCurrency(curr.ToUpper()))
            {
                ViewData["Error"] = "Currency " + curr + " cannot be removed!";
            }
            else
            {
                SelectListItem item = Account.watchlist.Where(x => x.Value.Equals(curr.ToUpper())).Select(x => x)
                    .FirstOrDefault();
                Account.watchlist.Remove(item);
                // return RedirectToPage("/Account/Manage/Account", new {area = "Identity"});

            }
        }
        return Page();
    }

    public async Task<IActionResult> OnPostCancel(String cardnumber,String ccv,String cardholder,String expirationdate,string amount)
    {
        return Page();
    }

    public async Task OnGet()
    {
        ViewData["Error"] = "";
    }

    private bool WatchListContainsCurrency(String currency)
    {
        List<String> currencies = watchlist.Where(x => x.Value.Equals(currency)).Select(x => x.Value).ToList();
        if (currencies.Any())
        {
            return true;
        }

        return false;
    }
}