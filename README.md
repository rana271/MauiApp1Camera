Step 1 Add nuget Camera.MAUI
step 2 assign permission in Platform folder for Ios and Andrid
below is the permisision
<uses-permission android:name="android.permission.CAMERA" />
	<uses-permission android:name="android.permission.RECORD_AUDIO" />
	<uses-permission android:name="android.permission.RECORD_VIDEO" />
 IOs
 <key>XSAppIconAssets</key>
	<string>Assets.xcassets/appicon.appiconset</string>
	<key>NSCameraUsageDescription</key>
<string>This app uses camera for...</string>
<key>NSMicrophoneUsageDescription</key>
<string>This app needs access to the microphone for record videos</string>
Step 3 Xaml page add the name space and design the control
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:cv="clr-namespace:Camera.MAUI;assembly=Camera.MAUI"
             x:Class="MauiApp1Camera.MainPage">

    <VerticalStackLayout
            Spacing="25"
            Padding="30,0"
            VerticalOptions="Fill"
            HorizontalOptions="Fill">
        <cv:CameraView x:Name="cameraView" WidthRequest="300" HeightRequest="200" CamerasLoaded="cameraView_CamerasLoaded"/>
        <Button Text="Smile!" Clicked="Button_Clicked" />

        <Image x:Name="myImage" WidthRequest="200" HeightRequest="200" />
    </VerticalStackLayout>

</ContentPage>
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

