using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class AccuWeatherService : IAccuWeatherService
    {
        private const string base_url = "http://dataservice.accuweather.com";
        private const string autocomplete_endpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language={2}";
        private const string current_conditions_endpoint = "currentconditions/v1/{0}?apikey={1}&language={2}";
        private const string past6h_conditions_endpoint = "currentconditions/v1/{0}/historical/?apikey={1}&language={2}";
        private const string past24h_conditions_endpoint = "currentconditions/v1/{0}/historical/24?apikey={1}&language={2}";
        private const string country_endpoint = "locations/v1/{0}?apikey={1}&language={2}";

        private const string api_key = "1ajntIGhu4eX9Yf9BtnpDLLrTfT9B9GQ";
        private const string language = "pl";

        // Dodanie dependency injections - użycie interefejsu i przekazywanie obiektu klasy
        // HttpClient w konstruktorze, żeby nie tworzyć nowego obiektu w każdej metodzie klasy
        // AccuWeatherService.


        private readonly HttpClient httpClient;

        public AccuWeatherService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<City[]> GetLocations(string locationName)
        {
            string uri = base_url + "/" + string.Format(autocomplete_endpoint, api_key, locationName, language);
            // using (HttpClient client = new HttpClient())
            // {
            var response = await httpClient.GetAsync(uri);
            string json = await response.Content.ReadAsStringAsync();
            City[] cities = JsonConvert.DeserializeObject<City[]>(json);
            return cities;

            //}
        }

        public async Task<Weather> GetCurrentConditions(string cityKey)
        {
            string uri = base_url + "/" + string.Format(current_conditions_endpoint, cityKey, api_key, language);
            //  using (HttpClient client = new HttpClient())
            //{
            var response = await httpClient.GetAsync(uri);
            string json = await response.Content.ReadAsStringAsync();
            Weather[] weathers = JsonConvert.DeserializeObject<Weather[]>(json);
            return weathers.FirstOrDefault();
            //}
        }


        public async Task<Weather> GetPast6hConditions(string cityKey)
        {
            string uri = base_url + "/" + string.Format(past6h_conditions_endpoint, cityKey, api_key, language);
            // using (HttpClient client = new HttpClient())
            //{
            var response = await httpClient.GetAsync(uri);
            string json = await response.Content.ReadAsStringAsync();
            Weather[] weathers = JsonConvert.DeserializeObject<Weather[]>(json);
            return weathers.FirstOrDefault();
            //}
        }

        public async Task<Weather> GetPast24hConditions(string cityKey)
        {
            string uri = base_url + "/" + string.Format(past24h_conditions_endpoint, cityKey, api_key, language);
            // using (HttpClient client = new HttpClient())
            //{
            var response = await httpClient.GetAsync(uri);
            string json = await response.Content.ReadAsStringAsync();
            Weather[] weathers = JsonConvert.DeserializeObject<Weather[]>(json);
            return weathers.FirstOrDefault();
            //}
        }

        public async Task<City> GetCountry(string cityKey)
        {
            string uri = base_url + "/" + string.Format(country_endpoint, cityKey, api_key, language);
            // using (HttpClient client = new HttpClient())
            //{
            var response = await httpClient.GetAsync(uri);
            string json = await response.Content.ReadAsStringAsync();
            City[] cities = JsonConvert.DeserializeObject<City[]>(json);
            return cities.FirstOrDefault();
            // }
        }
    }
}
