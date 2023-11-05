using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public interface IAccuWeatherService
    {
        Task<City[]> GetLocations(string locationName);
        Task<Weather> GetCurrentConditions(string cityKey);
        Task<Weather> GetPast6hConditions(string cityKey);
        Task<Weather> GetPast24hConditions(string cityKey);
        Task<City> GetCountry(string cityKey);
    }
}