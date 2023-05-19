using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace WebWeather.Pages;
public class HistoryModel : PageModel
{
    private readonly Baza.schowek _context;

    public List<Baza> BazaItems { get; set; }

    public HistoryModel(Baza.schowek context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        BazaItems = _context.tablica.ToList();
        return Page();
    }
}

