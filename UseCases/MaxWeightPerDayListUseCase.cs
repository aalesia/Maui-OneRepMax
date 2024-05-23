
namespace MauiApp1;

public class MaxWeightPerDayListUseCase : IUseCase<List<WorkoutRecordEntity>, List<WorkoutRecordEntity>>
{
    public Task<List<WorkoutRecordEntity>> Execute(List<WorkoutRecordEntity> input)
    {
        var results = input
            .GroupBy(x => x.Date.Date)
            .Select(g =>
            {
                var maxWeightRecord = g.Aggregate((max, current) => (current.Weight > max.Weight) ? current : max);
                Console.WriteLine($"Max weight for {g.Key}: {maxWeightRecord.Weight}");
                return maxWeightRecord;
            })
            .ToList();

        return Task.FromResult(results);
    }
}
