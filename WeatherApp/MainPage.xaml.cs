using WeatherApp.Mechanics;
using WeatherApp.Mechanics.Model;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        private WeatherData Data { get; set; }
        private ApiAccess api { get; set; }

        public MainPage(ApiAccess _api) {
            // initalize ApiAccess class
            api = _api;

            // initalize page
            InitializeComponent();
            PopulateData();
        }

        private async Task GetData() {
            // Request Weather data and store result to Data
            Data = await api.GetWeatherData();

        }

        private static Label GenerateDataLabel(string sensor, string value, string symbol) {
            var stringSymbol = "";
            if (symbol == "&deg;F" || symbol == "&deg;")
            {
                stringSymbol = "°";
            } else {
                stringSymbol = symbol;
            }

            Label lbl = new Label
            {
                Text = $"{sensor}: {value} {stringSymbol}",
                FontSize = 20,
                TextColor = Colors.White
            };

            return lbl;
        }

        private async void PopulateData() {
            await GetData();


            foreach (Reading reading in Data.record.readings)
            {
                var label = GenerateDataLabel(reading.sensor, reading.value.ToString(), reading.unit_symbol);
                DataStack.Add(label);
            }



            //"Rain Gauge"
            // Hygrometer
            // Dewpoint
            // "Anemometer"
            //		unit_symbol



        }
    }

}
