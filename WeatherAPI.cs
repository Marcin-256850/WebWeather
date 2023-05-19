using System.IO;
using System.Security.AccessControl;
using System.Text.Json;
using System.Text;
using static System.Net.WebRequestMethods;
using Microsoft.EntityFrameworkCore;


namespace WebWeather
{
    public class WeatherAPI
    {
        public async Task<string> downloadData(string mojePole) //funkcja asynchroniczna, wymaga zwrocenie obiektu typu task
        {
            string city = mojePole;
            HttpClient client = new HttpClient();
            string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&lang={2}", city, "3a16dd8f140e60db761996554d1febff", "pl");
            string json = await client.GetStringAsync(url);
            return json;
        }
    }
}
