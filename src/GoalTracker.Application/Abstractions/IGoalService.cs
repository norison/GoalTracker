using GoalTracker.Application.Models;

namespace GoalTracker.Application.Abstractions;

public interface IGoalService
{
    Task AddGoalAsync(Goal goal, CancellationToken cancellationToken = default);
    Task UpdateGoalAsync(Goal goal, CancellationToken cancellationToken = default);
    Task DeleteGoalAsync(Goal goal, CancellationToken cancellationToken = default);
    Task<Goal?> GetGoalByGuidAsync(Guid guid, CancellationToken cancellationToken = default);
    Task<IEnumerable<Goal>> GetGoalsAsync(CancellationToken cancellationToken = default);
}