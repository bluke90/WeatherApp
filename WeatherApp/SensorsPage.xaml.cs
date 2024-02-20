using WeatherApp.Mechanics;
using WeatherApp.Mechanics.Model;

namespace WeatherApp;

public partial class SensorsPage : ContentPage
{

    private WeatherData Data { get; set; }
    private ApiAccess api { get; set; }

    public SensorsPage(ApiAccess _api)
	{
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

    // Generate data label inside frame
    private static Frame GenerateDataLabel(string sensor, string value, string symbol) {
        // Init frame
        var frame = new Frame()
        {
            BorderColor = Colors.White,
            Background = Color.FromRgba("#121212"),
            CornerRadius = 0,
            Padding = new Thickness(10)
        };

        // Check for degrees and change to text symbol
        var stringSymbol = "";
        if (symbol == "&deg;F" || symbol == "&deg;")
        {
            stringSymbol = "°";
        } else
        {
            stringSymbol = symbol;
        }
        // init label
        Label lbl = new Label
        {
            Text = $"{sensor}: {value} {stringSymbol}",
            FontSize = 18,
            TextColor = Colors.White
        };
        frame.Content = lbl;

        return frame;
    }

    // Populate data for sensor page
    private async void PopulateData() {
        // get data
        await GetData();

        // populate data label for each sensor
        foreach (Reading reading in Data.record.readings)
        {
            var frame = GenerateDataLabel(reading.sensor, reading.value.ToString(), reading.unit_symbol);
            DataStack.Add(frame);
        }
    }

}