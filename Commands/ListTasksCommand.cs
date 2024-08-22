using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using ConsoleTables;
using TasksApp.Infrastructure;

namespace TasksApp.Commands;

public class ListTasksCommand : Command
{
    private readonly Option listAllTasksOption = new Option<bool>(name: "--all", description: "Lists all tasks");

    public ListTasksCommand()
        : base("list", "Lists all tasks")
    {
        this.AddOption(listAllTasksOption);
        this.SetHandler(OnList);
    }

    private void OnList(InvocationContext context)
    {
        bool isPresent = context.ParseResult.HasOption(listAllTasksOption);

        using var db = new TasksContext();
        var tasks = isPresent ?
            db.Tasks.ToList() :
            db.Tasks.Where(t => t.IsCompleted == false).ToList();

        ConsoleTable table = isPresent ? new("Id", "Title", "Created", "Completed") : new("Id", "Title", "Created");

        foreach (var task in tasks)
        {
            if (isPresent)
            {
                table.AddRow(task.Id, task.Title, task.CreatedAt, task.IsCompleted);
            }
            else
            {
                table.AddRow(task.Id, task.Title, task.CreatedAt);
            }
        }

        table.Write();
    }

}
