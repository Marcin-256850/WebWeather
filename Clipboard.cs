using Microsoft.EntityFrameworkCore;

namespace WebWeather
{
    public class Clipboard
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string Temperature { get; set; }
        public string Pressure { get; set; }
        public string WindSpeed { get; set; }
    }
}
