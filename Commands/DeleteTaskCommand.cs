using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using TasksApp.Infrastructure;

namespace TasksApp.Commands;

public class DeleteTaskCommand : Command
{

    private readonly Argument taskIdArg = new Argument<int>("task id", "The id of the task to be marked as completed");

    public DeleteTaskCommand()
        : base("delete", "Deletes a task by id")
    {
        this.AddArgument(taskIdArg);
        this.SetHandler(OnRemove);
    }

    private void OnRemove(InvocationContext context)
    {
        int? id = (int?)context.ParseResult.GetValueForArgument(taskIdArg);

        using var db = new TasksContext();
        Models.Task task = db.Tasks.Find(id) ?? throw new InvalidOperationException("Task not found");

        db.Remove(task);
        db.SaveChanges();
    }

}
