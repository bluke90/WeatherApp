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

        private async void PopulateData() {
            await GetData();

            temp.Text = Data.GetSensorValue("Thermometer");
            windLbl.Text = $"{Data.GetCardinalDirection()} @ {Data.GetSensorValue("10 Minute Wind Gust")} mph";
            humidityLbl.Text = $"{Data.GetSensorValue("Hygrometer")}%";
            rainfallLbl.Text = $"{Data.GetSensorValue("Rain Gauge")} in.";
        }

        private async Task GetData() {
            // Request Weather data and store result to Data
            Data = await api.GetWeatherData();

        }
    }

}
