# Tasks App

## Objective

The objective of this project is to build a CLI application for managing tasks aka todo in the terminal.

```sh
TasksApp [command] [options]
```

## Commands

### Add command

The **_add_** command is used to create a task and store it on the sqlite db.

```c#
dotnet run add <title> [options]
```

Example:

```sh
dotnet run add "Pick up dry cleaning at 4pm."
```

#### Options

- `--completed` options marks a task as completed upon creation.

```sh
dotnet run add "Go to the gym."  --completed
```

### List command

To view the tasks that has just been created, use the **_list_** command.

```sh
dotnet run list
```

Example:

```c#
dotnet run list
```

We only see one task, this is because by default the **_list_** command only  
displays tasks that have not been **completed**.

```c#
dotnet run list --all
```

### Complete command

This command is used to mark a task as completed.

```c#
dotnet run complete <task ID>
```

Example:

```sh
dotnet run complete 1
```

list all tasks using the command `dotnet run list --all`.

### Delete command

The **_delete_** command as the name suggests is used to delete a task.

```sh
dotnet run delete <task ID>
```

Example:

```sh
dotnet run delete 1
```

The command above the task with the ID **1** from the database.

### Example Application

You can find an [example version](https://github.com/kvngdre/tasks-cli-app/releases/tag/v1.0.0) of this tasks app on the releases tab of this repo.

## Extra Features

- Change the IsComplete property of the Task data model to use a timestamp instead, which gives further information.
- Add an update task feature
- Implement the DueTime and DueDate features.
