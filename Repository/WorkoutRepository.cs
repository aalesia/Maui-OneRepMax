
using Microsoft.Maui;
using System.IO;
using System.Collections.Generic;

namespace MauiApp1;

public class WorkoutRepository : IRepository
{
    string fileName = "workoutdata.txt";

    public async Task<List<WorkoutRecordEntity>> GetWorkoutsAsync()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
        var data = new List<string[]>();

        using (var reader = new StreamReader(stream))
        {
            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                var values = line.Split(',');
                data.Add(values);
            }
        }

        var workouts = new List<WorkoutRecordEntity>();
        data.ForEach(x => 
        {
            var workout = new WorkoutRecordEntity
            {
                Date = DateTime.Parse(x[0]),
                Workout = x[1],
                Reps = int.Parse(x[2]),
                Weight = int.Parse(x[3])
            };

            workouts.Add(workout);
        });

        return workouts;
    }
}
