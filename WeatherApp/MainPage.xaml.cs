using WeatherApp.Mechanics;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage() {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e) {

            ApiAccess api = new ApiAccess();
            await api.GetWeatherData();

        }
    }

}
