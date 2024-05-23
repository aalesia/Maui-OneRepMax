using System.ComponentModel;
using Microcharts;
using SkiaSharp;

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

    private Chart _lineChart;
    public Chart LineChart
    {
        get { return _lineChart; }
        set
        {
            if (_lineChart != value)
            {
                _lineChart = value;
                OnPropertyChanged(nameof(LineChart));
            }
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
        UpdateChart();
    }

    async void UpdateChart() {
        var useCase = DI.GetMaxWeightPerDayListUseCase();
        var records = await Task.Run(() => useCase.Execute(Workout.Records));
        var entries = new List<ChartEntry>();

        foreach (var item in records)
        {
            Console.WriteLine($"Weight: {item.Weight}");
            
            entries.Add(new ChartEntry((float)item.Weight)
            {
                Color = SKColor.Parse("#266489"),
                Label = item.Date.ToString(),
                ValueLabel = item.Weight.ToString()
            });
        }

        LineChart = new LineChart { Entries = entries };
    }
}
