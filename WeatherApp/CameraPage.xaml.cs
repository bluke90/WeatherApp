using WeatherApp.Mechanics;
using WeatherApp.Mechanics.Model;

namespace WeatherApp;

public partial class CameraPage : ContentPage
{

	private ApiAccess api { get; set; }
    private WeatherData Data { get; set; }

    public CameraPage(ApiAccess _api)
	{
		api = _api;

		InitializeComponent();
		PopulateData();
	}

	private static Image GenerateImage(string data) {

		Image img = new Image
		{
			Source = ImageSource.FromUri(new Uri(data))
		};

		return img;
	}

	private async void PopulateData() {
		Data = await api.GetWeatherData();

		foreach (Camera camera in Data.station.cameras)
		{
			Image img = GenerateImage(camera.image);
			CameraStack.Add(img);
		}
		


	}



}