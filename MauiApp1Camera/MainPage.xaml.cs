using Camera.MAUI;

namespace MauiApp1Camera;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	

    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.NumCamerasDetected > 0)
        {
            cameraView.Camera = cameraView.Cameras.First();

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        myImage.Source = cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);

    }
}

