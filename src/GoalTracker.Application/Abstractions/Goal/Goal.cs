namespace GoalTracker.Application.Abstractions.Goal;

public class Goal
{
    public Guid Id { get; set; }
    public int Year { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal InitialAmount { get; set; }
    public decimal CurrentAmount { get; set; }
    public decimal TargetAmount { get; set; }
}