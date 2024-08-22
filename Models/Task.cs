namespace TasksApp.Models;

public class Task(string title)
{
    public int Id { get; set; }
    public string Title { get; set; } = title;
    public bool IsCompleted { get; set; }
    public DateOnly? DueDate { get; set; } = null;
    public TimeOnly? DueTime { get; set; } = null;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}