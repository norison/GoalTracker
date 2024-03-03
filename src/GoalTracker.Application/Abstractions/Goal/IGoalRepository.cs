namespace GoalTracker.Application.Abstractions.Goal;

public interface IGoalRepository
{
    Task AddGoalAsync(Goal goal, CancellationToken cancellationToken = default);
    Task UpdateGoalAsync(Goal goal, CancellationToken cancellationToken = default);
    Task DeleteGoalAsync(Goal goal, CancellationToken cancellationToken = default);
    Task<Goal?> GetGoalByGuidAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Goal>> GetGoalsAsync(CancellationToken cancellationToken = default);
}