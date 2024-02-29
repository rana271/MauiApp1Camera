using Camera.MAUI;
using Microsoft.Extensions.Logging;

namespace MauiApp1Camera;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .UseMauiCameraView(); // Add the use of the plugging

        return builder.Build();
    }
}
