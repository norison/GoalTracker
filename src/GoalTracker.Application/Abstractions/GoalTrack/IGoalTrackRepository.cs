namespace GoalTracker.Application.Abstractions.GoalTrack;

public interface IGoalTrackRepository
{
    Task AddGoalTrackAsync(GoalTrack goalTrack, CancellationToken cancellationToken = default);
    Task<IEnumerable<GoalTrack>> GetGoalTracksAsync(CancellationToken cancellationToken = default);
    Task<GoalTrack?> GetGoalTrackByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task UpdateGoalTrackAsync(GoalTrack goalTrack, CancellationToken cancellationToken = default);
    Task DeleteGoalTrackAsync(Guid id, CancellationToken cancellationToken = default);
}