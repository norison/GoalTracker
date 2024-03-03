using System.ComponentModel.DataAnnotations;

namespace GoalTracker.Persistence.Options;

public class CsvOptions
{
    [Required] public string FolderPath { get; set; } = string.Empty;
}