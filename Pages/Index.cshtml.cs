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
        private readonly Baza.schowek _context;

        public string MojePole { get; set; }
        public Class Class { get; set; }
        public IndexModel(Baza.schowek context)
        {
            _context = context;
            var allElements = context.tablica.ToList();
            foreach (var element in allElements)
            {
                context.tablica.Remove(element);
            }
            context.SaveChanges();
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync(string mojePole)
        {
            WeatherAPI weatherAPI = new WeatherAPI();
            var json = await weatherAPI.downloadData(mojePole);
            WeatherInfo.root info = JsonSerializer.Deserialize<WeatherInfo.root>(json);

            var context = new schowek();
            var allElements = context.tablica.ToList();
            foreach (var element in allElements)
            {
                context.tablica.Remove(element);
            }
            context.SaveChanges();
            context.tablica.Add(new Baza { name = mojePole, icon = "https://openweathermap.org/img/w/" + info.weather[0].icon + ".png", description = info.weather[0].description, temperature = (info.main.temp - 273.5).ToString("n0") + "°C", pressure = info.main.pressure + " hPa", windspeed = info.wind.speed.ToString() + " m/s" });
            context.SaveChanges();

            Class = new Class
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