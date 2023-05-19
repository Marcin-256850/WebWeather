using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace WebWeather.Pages;
public class HistoryModel : PageModel
{
    private readonly Baza.Board _context;

    public List<Baza> BazaItems { get; set; }

    public HistoryModel(Baza.Board context)
    {
        _context = context;
    }
    public IActionResult OnPost()
    {
        var allElements = _context.tablica.ToList();
        foreach (var element in allElements)
        {
            _context.tablica.Remove(element);
        }
        _context.SaveChangesAsync();
        return RedirectToPage();
    }
    public IActionResult OnGet()
    {
        BazaItems = _context.tablica.ToList();
        return Page();
    }
}

