namespace MauiApp1;

public class DI
{
    public static IRepository GetRepository() {
        return Application.Current.MainPage.Handler.MauiContext.Services.GetService<IRepository>();
    }

    public static IDataSource<WorkoutEntity> GetWorkoutDataSource() {
        return Application.Current.MainPage.Handler.MauiContext.Services.GetService<IDataSource<WorkoutEntity>>();
    }

    public static IUseCase<List<WorkoutEntity>> GetParseWorkoutLogUseCase() {
        return Application.Current.MainPage.Handler.MauiContext.Services.GetService<IUseCase<List<WorkoutEntity>>>();
    }

    public static IUseCase<List<WorkoutRecordEntity>, List<WorkoutRecordEntity>> GetMaxWeightPerDayListUseCase() {
        return Application.Current.MainPage.Handler.MauiContext.Services.GetService<IUseCase<List<WorkoutRecordEntity>, List<WorkoutRecordEntity>>>();
    }

    public static MainPageViewModel GetMainPageViewModel() {
        return Application.Current.MainPage.Handler.MauiContext.Services.GetService<MainPageViewModel>();
    }

    public static DetailsPageViewModel GetDetailsPageViewModel() {
        return Application.Current.MainPage.Handler.MauiContext.Services.GetService<DetailsPageViewModel>();
    }
}
