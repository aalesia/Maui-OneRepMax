namespace MauiApp1;

public class WorkoutDataSource : IDataSource<WorkoutEntity>
{
    readonly List<WorkoutEntity> _workouts = new();
    public void AddRecord(WorkoutEntity record)
    {
        _workouts.Add(record);
    }

    public void AddRecords(List<WorkoutEntity> records)
    {
        _workouts.AddRange(records);
    }

    public WorkoutEntity GetRecord(string name)
    {
        return _workouts.Find(record => record.Name == name);
    }

    public List<WorkoutEntity> GetRecords()
    {
        return _workouts;
    }

    public void ClearRecords()
    {
        _workouts.Clear();
    }
}
