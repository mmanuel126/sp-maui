using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using sp_maui;
using sp_maui.Helper;

namespace sp_maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
       // builder.Services.AddSingleton<ILoadingPageService, LoadingPageService>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
