namespace WebWeather
{
    public class WeatherInfo
    {
        public class coord
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }

        public class weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class main
        {
            public string name { get; set; }
            public double temp { get; set; }

            public double feels_like { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }

        }

        public class wind
        {
            public double speed { get; set; }
        }

        public class root
        {
            public coord coord { get; set; }
            public List<weather> weather { get; set; }
            public main main { get; set; }
            public wind wind { get; set; }

            public static implicit operator string?(root? v)
            {
                throw new NotImplementedException();
            }

        }
    }
}

