namespace MauiApp1;

public struct WorkoutEntity
{
    public string Name { get; set; }
    public int MaxRep { get; set; }
    public List<WorkoutRecordEntity> Records { get; set; }
}
