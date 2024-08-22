using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using TasksApp.Infrastructure;

namespace TasksApp.Commands;

public class AddTaskCommand : Command
{
    private readonly Argument titleArg = new Argument<string>("Title", "The title of the task.");
    private readonly Option taskCompletedOption = new Option<bool>(name: "--completed", description: "Marks task as completed");


    public AddTaskCommand()
        : base("add", "Adds a new task to the database")
    {
        this.AddArgument(titleArg);
        this.AddOption(taskCompletedOption);
        this.SetHandler(OnAdd);
    }


    void OnAdd(InvocationContext context)
    {
        string? title = (string?)context.ParseResult.GetValueForArgument(titleArg);
        bool isCompeted = context.ParseResult.HasOption(taskCompletedOption);

        Models.Task task = new(title!)
        {
            IsCompleted = isCompeted
        };

        using var db = new TasksContext();
        db.Add(task);
        db.SaveChanges();

        Console.WriteLine("Saved");
    }
}
