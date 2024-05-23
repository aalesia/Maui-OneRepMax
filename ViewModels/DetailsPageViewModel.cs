using System.ComponentModel;

namespace MauiApp1;

public class DetailsPageViewModel : INotifyPropertyChanged
{
    private WorkoutEntity _workout;
    public WorkoutEntity Workout
    {
        get { return _workout; }
        set
        {
            _workout = value;
            OnPropertyChanged(nameof(Workout));
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void FetchWorkout(string name)
    {
        var dataSource = DI.GetWorkoutDataSource();
        Workout = dataSource.GetRecord(name);
    }
}
