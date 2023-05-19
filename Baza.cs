using Microsoft.EntityFrameworkCore;

namespace WebWeather
{
    public class Baza
    {
            public int Id { get; set; }
            public string name { get; set; }
            public string icon { get; set; }
            public string description { get; set; }
            public string temperature { get; set; }
            public string pressure { get; set; }
            public string windspeed { get; set; }

        public class schowek : DbContext
        {
            public virtual DbSet<Baza> tablica { get; set; }

            public schowek()
            {
                Database.EnsureCreated();
            }
            protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(@"Data Source=baza_danych.db");
        }
    }
}
