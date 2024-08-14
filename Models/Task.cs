namespace TasksApp.Models;

public class Task
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateOnly? DueDate { get; set; } = null;
    public TimeOnly? DueTime { get; set; } = null;
}