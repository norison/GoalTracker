using GoalTracker.Application.Abstractions.GoalTrack;
using GoalTracker.Persistence.Implementation.Base;
using GoalTracker.Persistence.Options;
using Microsoft.Extensions.Options;

namespace GoalTracker.Persistence.Implementation;

public class CsvGoalTrackRepository(IOptions<CsvOptions> options)
    : CsvRepositoryBase(Path.Combine(options.Value.FolderPath, "Data", "GoalTracks.csv")), IGoalTrackRepository
{
    public async Task AddGoalTrackAsync(GoalTrack goalTrack, CancellationToken cancellationToken = default)
    {
        var goalTracks = await GetGoalTracksAsync(cancellationToken);
        await WriteCsvAsync(goalTracks.Append(goalTrack), cancellationToken);
    }

    public async Task<IEnumerable<GoalTrack>> GetGoalTracksAsync(CancellationToken cancellationToken = default)
    {
        return await ReadCsvAsync<GoalTrack>(cancellationToken);
    }

    public async Task<GoalTrack?> GetGoalTrackByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var goalTracks = await GetGoalTracksAsync(cancellationToken);
        return goalTracks.FirstOrDefault(goalTrack => goalTrack.Id == id);
    }

    public async Task UpdateGoalTrackAsync(GoalTrack goalTrack, CancellationToken cancellationToken = default)
    {
        var goalTracks = await GetGoalTracksAsync(cancellationToken);
        var filteredGoalTracks = goalTracks.Where(x => x.Id == goalTrack.Id).Append(goalTrack);
        await WriteCsvAsync(filteredGoalTracks, cancellationToken);
    }

    public async Task DeleteGoalTrackAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var goalTracks = await GetGoalTracksAsync(cancellationToken);
        var filteredGoalTracks = goalTracks.Where(x => x.Id != id);
        await WriteCsvAsync(filteredGoalTracks, cancellationToken);
    }
}