using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using GoalTracker.Application.Abstractions;
using GoalTracker.Application.Models;

namespace GoalTracker.Persistence.Implementation;

public class CsvGoalService : IGoalService
{
    private readonly string _csvFilePath = Path.Combine("Data", "Goals.csv");

    private readonly CsvConfiguration _csvConfiguration = new(CultureInfo.InvariantCulture)
    {
        NewLine = Environment.NewLine
    };

    public async Task AddGoalAsync(Goal goal, CancellationToken cancellationToken = default)
    {
        var goals = await GetGoalsAsync(cancellationToken);
        await WriteCsvAsync(goals.Append(goal), cancellationToken);
    }

    public async Task UpdateGoalAsync(Goal goal, CancellationToken cancellationToken = default)
    {
        var goals = await GetGoalsAsync(cancellationToken);
        var filteredGoals = goals.Where(g => g.Guid != goal.Guid).Append(goal);
        await WriteCsvAsync(filteredGoals, cancellationToken);
    }

    public async Task DeleteGoalAsync(Goal goal, CancellationToken cancellationToken = default)
    {
        var goals = await GetGoalsAsync(cancellationToken);
        var filteredGoals = goals.Where(g => g.Guid != goal.Guid);
        await WriteCsvAsync(filteredGoals, cancellationToken);
    }

    public async Task<Goal?> GetGoalByGuidAsync(Guid guid, CancellationToken cancellationToken = default)
    {
        var goals = await GetGoalsAsync(cancellationToken);
        return goals.FirstOrDefault(goal => goal.Guid == guid);
    }

    public async Task<IEnumerable<Goal>> GetGoalsAsync(CancellationToken cancellationToken = default)
    {
        return await ReadCsvAsync<Goal>(cancellationToken);
    }

    private async Task<IEnumerable<T>> ReadCsvAsync<T>(CancellationToken cancellationToken = default)
    {
        return await Task.Run(() =>
        {
            using var reader = new StreamReader(_csvFilePath);
            using var csv = new CsvReader(reader, _csvConfiguration);
            return csv.GetRecords<T>();
        }, cancellationToken);
    }

    private async Task WriteCsvAsync<T>(IEnumerable<T> records, CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            using var writer = new StreamWriter(_csvFilePath);
            using var csv = new CsvWriter(writer, _csvConfiguration);
            csv.WriteRecords(records);
        }, cancellationToken);
    }
}