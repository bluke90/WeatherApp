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
        public string URL = "https://api.weatherstem.com/api";

        // HttpClient is basically the tool you use to communicate with the API interface
        public HttpClient client { get; set; }

        public ApiAccess() {
            // this is the initilization funciton, it will be run any time a new ApiAccess class is created


            client = new HttpClient();
            client.BaseAddress = new Uri(URL);


        }

        public async Task GetWeatherData() {
            
            // create a variable to hold the information for the request
            var values = new List<KeyValuePair<string, string>>();

            // add the data for the request to the values variable
            values.Add(new KeyValuePair<string, string>("input", "{'stations':['fsu@leon.weatherstem.com'],'api_key':'3t9tbbzi'}"));

            // Console.WriteLine just writes any data to the console so we dont have to make a whole page just to test
            Console.WriteLine(values[0]);

            // convert the request value into a URL request
            var content = new FormUrlEncodedContent(values);

            // Request should = "https://api.weatherstem.com/api?input={"api_key":"3t9tbbzi","stations":["msu@leon.weatherstem.com"]}"

            // Send the request and store the response in "response" variable
            var response = await client.PostAsync(URL, content);

            // Convert the response to english basically
            var responseString = await response.Content.ReadAsStringAsync();

            // print data out
            Console.WriteLine(responseString);
        }
        

    }
}
