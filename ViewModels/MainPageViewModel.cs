using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp1;

public class MainPageViewModel : INotifyPropertyChanged
{
    private ObservableCollection<WorkoutEntity> _workouts;
    public ObservableCollection<WorkoutEntity> Workouts
    {
        get { return _workouts; }
        set
        {
            if (_workouts != value)
            {
                _workouts = value;
                OnPropertyChanged(nameof(Workouts));
            }
        }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public async void FetchWorkouts()
    {
        var useCase = DI.GetParseWorkoutLogUseCase();
        var workouts = await Task.Run(() => useCase.Execute());
        Workouts = new ObservableCollection<WorkoutEntity>(workouts);
    }
}
