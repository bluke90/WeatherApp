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

    public class WeatherData
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

    public static class WeatherDataUtils {
        public static string GetSensorValue(this WeatherData data, string sensor) {
            string value;

            if (data == null)
            {
                throw new NullReferenceException();
            }

            Reading reading = data.record.readings.Where(reading => reading.sensor == sensor).FirstOrDefault();

            value = reading.value.ToString();

            return value;
        }

        public static string GetSensorSymbol(this WeatherData data, string sensor) {
            string value;

            if (data == null)
            {
                throw new NullReferenceException();
            }

            Reading reading = data.record.readings.Where(reading => reading.sensor == sensor).FirstOrDefault();

            value = reading.unit_symbol.ToString();

            return value;
        }

        public static double GetElevation(this WeatherData data) {

            double standard_bar = 29.92;
            double current_bar = double.Parse(data.GetSensorValue("Barometer"));
            double elevation = (current_bar - standard_bar)*1000;
            return elevation;
        }

        public static string GetCardinalDirection(this WeatherData data) {
            int degrees = int.Parse(data.GetSensorValue("Wind Vane"));

            // Make sure degrees are within the range [0, 360)
            degrees = (degrees % 360 + 360) % 360;

            // Define cardinal directions and their corresponding degree ranges
            string[] directions = { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW", "N" };
            double[] ranges = { 11.25, 33.75, 56.25, 78.75, 101.25, 123.75, 146.25, 168.75, 191.25, 213.75, 236.25, 258.75, 281.25, 303.75, 326.25, 348.75, 360.0 };

            // Find the correct cardinal direction
            for (int i = 0; i < directions.Length - 1; i++)
            {
                if (degrees < ranges[i + 1])
                {
                    return directions[i];
                }
            }

            // This should not happen, but just in case
            return "Unknown";
        }
    }

}
