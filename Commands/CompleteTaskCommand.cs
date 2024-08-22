using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using TasksApp.Infrastructure;

namespace TasksApp.Commands;

public class CompleteTaskCommand : Command
{
    private readonly Argument taskIdArg = new Argument<int>("task id", "The id of the task to be marked as completed");

    public CompleteTaskCommand()
        : base("complete", "Marks a task as completed by it's ID")
    {
        this.AddArgument(taskIdArg);
        this.SetHandler(OnComplete);
    }


    private void OnComplete(InvocationContext context)
    {
        int? id = (int?)context.ParseResult.GetValueForArgument(taskIdArg);

        using var db = new TasksContext();
        Models.Task? task = db.Tasks.Find(id);

        if (task == null)
        {
            throw new InvalidOperationException("Task not found");
        }

        task.IsCompleted = true;
        db.SaveChanges();
    }
}
