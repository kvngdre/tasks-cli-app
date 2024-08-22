using System;
using Microsoft.EntityFrameworkCore;
using TasksApp.Models;

namespace TasksApp.Infrastructure;

public class TasksContext : DbContext
{
    public string DbPath { get; }
    public DbSet<Models.Task> Tasks { get; set; } = null!;

    public TasksContext()
    {
        var path = Environment.CurrentDirectory;
        DbPath = System.IO.Path.Join(path + "/data", "tasks.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
;