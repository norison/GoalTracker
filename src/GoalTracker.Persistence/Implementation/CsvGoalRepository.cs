using GoalTracker.Application.Abstractions.Goal;
using GoalTracker.Persistence.Implementation.Base;
using GoalTracker.Persistence.Options;
using Microsoft.Extensions.Options;

namespace GoalTracker.Persistence.Implementation;

public class CsvGoalRepository(IOptions<CsvOptions> options)
    : CsvRepositoryBase(Path.Combine(options.Value.FolderPath, "Data", "Goals.csv")), IGoalRepository
{
    public async Task AddGoalAsync(Goal goal, CancellationToken cancellationToken = default)
    {
        var goals = await GetGoalsAsync(cancellationToken);
        await WriteCsvAsync(goals.Append(goal), cancellationToken);
    }

    public async Task UpdateGoalAsync(Goal goal, CancellationToken cancellationToken = default)
    {
        var goals = await GetGoalsAsync(cancellationToken);
        var filteredGoals = goals.Where(g => g.Id != goal.Id).Append(goal);
        await WriteCsvAsync(filteredGoals, cancellationToken);
    }

    public async Task DeleteGoalAsync(Goal goal, CancellationToken cancellationToken = default)
    {
        var goals = await GetGoalsAsync(cancellationToken);
        var filteredGoals = goals.Where(g => g.Id != goal.Id);
        await WriteCsvAsync(filteredGoals, cancellationToken);
    }

    public async Task<Goal?> GetGoalByGuidAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var goals = await GetGoalsAsync(cancellationToken);
        return goals.FirstOrDefault(goal => goal.Id == id);
    }

    public async Task<IEnumerable<Goal>> GetGoalsAsync(CancellationToken cancellationToken = default)
    {
        return await ReadCsvAsync<Goal>(cancellationToken);
    }
}