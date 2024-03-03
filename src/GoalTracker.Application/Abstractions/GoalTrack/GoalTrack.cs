namespace GoalTracker.Application.Abstractions.GoalTrack;

public class GoalTrack
{
    public Guid Id { get; set; }
    public Guid GoalId { get; set; }
    public DateOnly Date { get; set; }
    public decimal Amount { get; set; }
}