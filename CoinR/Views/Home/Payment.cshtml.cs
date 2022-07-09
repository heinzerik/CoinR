using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoinR.Views.Home;

public class Payment : PageModel
{
    public void OnGet()
    {
        
    }
    [HttpPost]
    public IActionResult Create()
    {
        return Page();
    }
}