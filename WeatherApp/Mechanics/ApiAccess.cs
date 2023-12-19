using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace WeatherApp.Mechanics
{
    public class ApiAccess
    {
        public string Key = "3t9tbbzi";
        public string JSONstr { get; set; }
        public string URL = "https://api.weatherstem.com/api";
        public HttpClient client { get; set; }

        public ApiAccess() {
            client = new HttpClient();
        }

        public async Task GetWeatherData() {
            var values = new List<KeyValuePair<string, string>>();

            values.Add(new KeyValuePair<string, string>("input", "{'stations':['msu@leon.weatherstem.com'], 'api_key':'" + Key + "'}"));
            Console.WriteLine("{'stations':['msu@leon.weatherstem.com'], 'api_key':'" + Key + "'}");

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(URL, content);

            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseString);
        }
        

    }
}
