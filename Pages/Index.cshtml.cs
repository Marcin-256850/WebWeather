using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static WebWeather.WeatherAPI;
using static WebWeather.Baza;
using System.Text.Json;
using System.Xml.Linq;

namespace WebWeather.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Baza.Board _context;

        public string MojePole { get; set; }
        public Clipboard Class { get; set; }
        public IndexModel(Baza.Board context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync(string mojePole)
        {
            WeatherAPI weatherAPI = new WeatherAPI();
            var json = await weatherAPI.downloadData(mojePole);
            WeatherInfo.root info = JsonSerializer.Deserialize<WeatherInfo.root>(json);

            var context = new Board();
            context.SaveChanges();
            context.tablica.Add(new Baza { name = mojePole, icon = "https://openweathermap.org/img/w/" + info.weather[0].icon + ".png", description = info.weather[0].description, temperature = (info.main.temp - 273.5).ToString("n0") + "°C", pressure = info.main.pressure + " hPa", windspeed = info.wind.speed.ToString() + " m/s" });
            context.SaveChanges();

            Class = new Clipboard
            {
                Name = mojePole,
                Icon = "https://openweathermap.org/img/w/" + info.weather[0].icon + ".png",
                Description = info.weather[0].description,
                Temperature = (info.main.temp - 273.5).ToString("n0") + "°C",
                Pressure = info.main.pressure + " hPa",
                WindSpeed = info.wind.speed.ToString() + " m/s",
            };
            

            return Page();
        }
    }
}