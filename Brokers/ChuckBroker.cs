using ChuckSwapi.Brokers.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChuckSwapi.Brokers
{
    public class ChuckBroker : IChuckBroker
    {
        private readonly string _baseUrl;
        public ChuckBroker(IConfiguration configuration)
        {
            _baseUrl = configuration.GetConnectionString("ChuckEndpoint");
        }
        public async Task<List<string>> GetAllCategories()
        {
            using var client = new HttpClient();
            var categories = new List<string>();
            var url = _baseUrl + "categories";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                categories = JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());
            }

            return categories;
        }

        public async Task<string> Search(string query)
        {
            using var client = new HttpClient();
            var url = $"{_baseUrl}search?query={query}";
            var response = await client.GetAsync(url);
            if(response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();
            return string.Empty;
        }
    }
}
