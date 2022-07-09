using System.Configuration;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Web.Helpers;
using System.Xml.Schema;
using Braintree;
using CoinR.Areas.Identity.Pages.Account.Manage;
using CoinR.Data;
using Microsoft.AspNetCore.Mvc;
using CoinR.Models;
using CoinR.Services;
using CoinR.Views.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using BraintreeService = CoinR.Services.BraintreeService;

namespace CoinR.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _dbContext;
    public static IBraintreeGateway gateway;
    private string clientToken;
    
    

    private readonly BraintreeService braintreeService;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext,BraintreeService braintreeService)
    {
        _logger = logger;
        _dbContext = dbContext;
        this.braintreeService = braintreeService;
    }

    public IActionResult Index()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);


        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Home()
    {
        gateway = braintreeService.createGateway();
        clientToken = gateway.ClientToken.Generate(); //Genarate a token
        ViewBag.clientToken = clientToken;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] //this turns off the cache
    public IActionResult Bitcoin()
    {
        Random rnd = new Random();
        //list of countries  
        var lstModel = new List<SimpleReportViewModel>();
        lstModel.Add(new SimpleReportViewModel
        {
            DimensionOne = "Brazil",
            Quantity = rnd.Next(10)
        });
        lstModel.Add(new SimpleReportViewModel
        {
            DimensionOne = "USA",
            Quantity = rnd.Next(10)
        });
        lstModel.Add(new SimpleReportViewModel
        {
            DimensionOne = "Portugal",
            Quantity = rnd.Next(10)
        });
        lstModel.Add(new SimpleReportViewModel
        {
            DimensionOne = "Russia",
            Quantity = rnd.Next(10)
        });
        lstModel.Add(new SimpleReportViewModel
        {
            DimensionOne = "Ireland",
            Quantity = rnd.Next(10)
        });
        lstModel.Add(new SimpleReportViewModel
        {
            DimensionOne = "Germany",
            Quantity = rnd.Next(10)
        });
        return View(lstModel);
    }

    public IActionResult Ethereum()
    {
        return View();
    }

    public IActionResult Litecoin()
    {
        return View();
    }

    public async Task<IActionResult> BuyPrediction([FromQuery] string currency)
    {
        string UserId = HttpContext.Session.GetString("UserId");

        string fundings = _userManager.getUserFundings(UserId).Result;
        string predictionprice = "27";

        if (Convert.ToDecimal(fundings) >= Convert.ToDecimal(predictionprice))
        {
            CryptoCurrencyService.GetAll().Where(x => x.name == currency.ToUpper()).FirstOrDefault().chart.Add("10");
            CryptoCurrencyService.GetAll().Where(x => x.name == currency.ToUpper()).FirstOrDefault().chart.Add("20");
            return View("Currencydetails");
        }

        return View("InsufficientFundings");
    }

    public IActionResult AddToWatchList(String currency)
    {
        if (!WatchListContainsCurrency(currency.ToUpper()))
        {
            Account.watchlist.Add(new SelectListItem(currency, currency.ToUpper(), false));

        }
        return RedirectToPage("/Account/Manage/Account", new {area = "Identity"});


    }

    public IActionResult RemoveFromWatchList(String curr)
    {
        if (WatchListContainsCurrency(curr.ToUpper()))
        {
            SelectListItem item = Account.watchlist.Where(x => x.Value.Equals(curr.ToUpper())).Select(x => x)
                .FirstOrDefault();
            Account.watchlist.Remove(item);
        }
        else
        {
            ModelState.AddModelError("Error", "Watchlist does not contain currency " + curr);
            return View("Index");
        }

        return RedirectToPage("/Account/Manage/Account", new {area = "Identity"});
    }

    public string getSelectedCurrency()
    {
        return Request.Form["currencyselect"].ToString();
    }


    private bool WatchListContainsCurrency(String currency)
    {
        List<String> currencies = Account.watchlist.Where(x => x.Value.Equals(currency)).Select(x => x.Value).ToList();
        if (currencies.Any())
        {
            return true;
        }

        return false;
    }


    public IActionResult Currencydetails([FromQuery] String currency)
    {
        string userId = HttpContext.Session.GetString("UserId");
        if (!String.IsNullOrEmpty(userId))
        {
            var viewmodel = new Currencydetails(currency);
            return View(viewmodel);
        }

        return LocalRedirect("/Identity/Account/Login");
    }

    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }

    public IActionResult InsufficientFundings()
    {
        return View("InsufficientFundings");
    }
}