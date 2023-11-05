using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherApp.Model;

namespace WeatherApp.ViewModel
{

    internal class WeatherAppViewModel
    {
        City selectedCity;
        AccuWeatherService accuWeatherService;
        public WeatherAppViewModel(City selectedCity, AccuWeatherService accuWeatherService)
        {
            this.selectedCity = selectedCity;
            this.accuWeatherService = accuWeatherService;
        }

        public async Task<string[]> GetData()
        {
            string[] data = new string[4];
            string key = selectedCity.Key;

            string administrativeArea = selectedCity.AdministrativeArea.LocalizedName;
            data[0] = administrativeArea;

            var weather = await accuWeatherService.GetCurrentConditions(key);
            double tempValue = weather.Temperature.Metric.Value;
            data[1] = Convert.ToString(tempValue);

            var past6hWeather = await accuWeatherService.GetPast6hConditions(key);
            double past6hTempValue = past6hWeather.Temperature.Metric.Value;
            data[2] = Convert.ToString(past6hTempValue);

            var past24hWeather = await accuWeatherService.GetPast24hConditions(key);
            double past24hTempValue = past24hWeather.Temperature.Metric.Value;
            data[3] = Convert.ToString(past24hTempValue);

            return data;

            
        }
    }
}
