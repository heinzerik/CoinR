using Braintree;
using CoinR.Controllers;
using CoinR.Models;
using CoinR.Views.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BraintreeService = CoinR.Services.BraintreeService;

namespace CoinR.Areas.Identity.Pages.Account.Manage;

public class Account : PageModel
{

    public String Id = "";
    public static String? currencyselectValue = "Bitcoin";
    public readonly BraintreeService braintreeService;
    
    
    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public string Currency { get; set; }

    public Account(BraintreeService braintreeService)
    {
        this.braintreeService = braintreeService; 
    }

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


    public IActionResult Payment()
    {
        var gateway = braintreeService.getGaitway();
        var clientToken = gateway.ClientToken.Generate();
        ViewData["CLientToken"] = clientToken;
        var data = new BookPurchaseVM
        {
            Id = 2,
            Description = "Hellow man",
            Author = "Me",
            Thumbnail = "This is thumbnail",
            Title = "This is title",
            Price = "230",
            Nonce = ""
        };
        return Page();
    }

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

    public async Task<IActionResult> OnPostCancel(String cardnumber, String ccv, String cardholder,
        String expirationdate, string amount)
    {
        return Page();
    }

    public async Task OnGet()
    {
        ViewData["ClientToken"] = 
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