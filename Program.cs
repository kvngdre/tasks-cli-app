using System.CommandLine;
using System.CommandLine.Parsing;
using TasksApp.Commands;

RootCommand rootCommand = new(description: "Command line app for creating and managing tasks");

rootCommand.AddCommand(new AddTaskCommand());
rootCommand.AddCommand(new ListTasksCommand());
rootCommand.AddCommand(new CompleteTaskCommand());
rootCommand.AddCommand(new DeleteTaskCommand());

await rootCommand.InvokeAsync(args);
