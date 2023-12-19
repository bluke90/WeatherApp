using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Mechanics.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Camera
    {
        public string image { get; set; }
        public string name { get; set; }
    }

    public class Domain
    {
        public string name { get; set; }
        public string handle { get; set; }
    }

    public class Hilo
    {
        public int min { get; set; }
        public int max { get; set; }
        public string property { get; set; }
        public string unit { get; set; }
        public string max_time { get; set; }
        public string symbol { get; set; }
        public string min_time { get; set; }
        public string type { get; set; }
        public string name { get; set; }
    }

    public class Reading
    {
        public string sensor_type { get; set; }
        public string unit { get; set; }
        public int transmitter { get; set; }
        public object value { get; set; }
        public string sensor { get; set; }
        public int id { get; set; }
        public string unit_symbol { get; set; }
    }

    public class Record
    {
        public string time { get; set; }
        public List<Reading> readings { get; set; }
        public string last_rain_time { get; set; }
        public int derived { get; set; }
        public string down_since { get; set; }
        public string now { get; set; }
        public int id { get; set; }
        public Hilo hilo { get; set; }
    }

    public class Root
    {
        public Record record { get; set; }
        public Station station { get; set; }
    }

    public class Station
    {
        public List<Camera> cameras { get; set; }
        public string lat { get; set; }
        public Domain domain { get; set; }
        public string name { get; set; }
        public string handle { get; set; }
        public string twitter { get; set; }
        public string wunderground { get; set; }
        public string facebook { get; set; }
        public string lon { get; set; }
    }

}
