using Microsoft.Extensions.Logging;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.RegisterRepository()
			.RegisterDataSources()
			.RegisterUseCases()
			.RegisterViewModels();
		
		Routing.RegisterRoute("MainPage", typeof(MainPage));
		Routing.RegisterRoute("DetailsPage", typeof(DetailsPage));

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	public static MauiAppBuilder RegisterRepository(this MauiAppBuilder mauiAppBuilder)
	{
    	mauiAppBuilder.Services.AddSingleton<IRepository, WorkoutRepository>();
		return mauiAppBuilder;
	}

	public static MauiAppBuilder RegisterDataSources(this MauiAppBuilder mauiAppBuilder)
	{
    	mauiAppBuilder.Services.AddSingleton<IDataSource<WorkoutEntity>, WorkoutDataSource>();
		return mauiAppBuilder;
	}

	public static MauiAppBuilder RegisterUseCases(this MauiAppBuilder mauiAppBuilder)
	{
    	mauiAppBuilder.Services.AddSingleton<IUseCase<List<WorkoutEntity>>, ParseWorkoutLogUseCase>();
		return mauiAppBuilder;
	}

	public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
	{
    	mauiAppBuilder.Services.AddSingleton<MainPageViewModel>();
		mauiAppBuilder.Services.AddSingleton<DetailsPageViewModel>();
		return mauiAppBuilder;
	}
}
