using ChuckSwapi.Brokers.Interfaces;
using ChuckSwapi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChuckSwapi.Brokers
{
    public class SWBroker : ISWBroker
    {
        private readonly string _baseUrl;
        public SWBroker(IConfiguration configuration)
        {
            _baseUrl = configuration.GetConnectionString("SwapiEndpoint");
        }

        public async Task<List<Person>> GetAllPeople()
        {
            using var client = new HttpClient();
            var people = new List<Person>();
            var response = await client.GetAsync(_baseUrl);
            if (response.IsSuccessStatusCode)
            {
                people = JsonConvert.DeserializeObject<SwapiResponse>(await response.Content.ReadAsStringAsync())?.Results;
            }

            return people;
        }

        public async Task<Person> Search(string query)
        {
            using var client = new HttpClient();
            Person result = null;
            var url = $"{_baseUrl}?search={query}";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var see = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<SwapiResponse>(await response.Content.ReadAsStringAsync())?.Results.FirstOrDefault();
            }

            return result;
        }
    }
}
