namespace MauiApp1;

public interface IRepository
{
    Task<List<WorkoutRecordEntity>> GetWorkoutsAsync();
}
