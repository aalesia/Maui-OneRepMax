namespace MauiApp1;

public class ParseWorkoutLogUseCase : IUseCase<List<WorkoutEntity>>
{
    readonly IRepository _repository;
    readonly IDataSource<WorkoutEntity> _dataSource;

    public ParseWorkoutLogUseCase()
    {
        _repository = DI.GetRepository();
        _dataSource = DI.GetWorkoutDataSource();
    }

    public Task<List<WorkoutEntity>> Execute()
    {
        var workoutRecords = _repository.GetWorkoutsAsync().Result;
        var groupedWorkoutRecords = workoutRecords.GroupBy(x => x.Workout);
        var sortedWorkouts = new List<WorkoutEntity>();
        foreach (var group in groupedWorkoutRecords)
        {
            var workout = new WorkoutEntity
            {
                Name = group.Key,
                MaxRep = group.Max(x => x.Weight),
                Records = group.OrderByDescending(x => x.Date).ToList()
            };

            sortedWorkouts.Add(workout);
        }

        _dataSource.ClearRecords();
        _dataSource.AddRecords(sortedWorkouts.OrderBy(x => x.Name).ToList());

        return Task.FromResult(_dataSource.GetRecords());
    }
}
