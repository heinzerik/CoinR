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
    private IBraintreeGateway gateway;
    private String clientToken = "";
    public string Nonce = "";
    public static string nonce = "";
    
    
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

    public async Task<IActionResult> OnPost(String paymentmethod)
    {
        var gateway = braintreeService.getGateway();
        var request = new TransactionRequest
        {
            Amount = Convert.ToDecimal("250"),
            PaymentMethodNonce = nonce,
            Options = new TransactionOptionsRequest
            {
                SubmitForSettlement = true
            }
        };

        Result<Transaction> result = gateway.Transaction.Sale(request);

        if (result.IsSuccess())
        {
            return Page();
        }
        else
        {
            return NotFound();
        }
    }

    public async Task OnGet()
    {
        IBraintreeGateway gateway = braintreeService.getGateway();
        clientToken = gateway.ClientToken.Generate();
        ViewData["CLientToken"] = clientToken;
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