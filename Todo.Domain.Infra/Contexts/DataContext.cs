using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<TodoItem> Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>().Property(todoItem => todoItem.Id);
        modelBuilder.Entity<TodoItem>().Property(todoItem => todoItem.User).HasMaxLength(120);
        modelBuilder.Entity<TodoItem>().Property(todoItem => todoItem.Title).HasMaxLength(160);
        modelBuilder.Entity<TodoItem>().Property(todoItem => todoItem.Done);
        modelBuilder.Entity<TodoItem>().Property(todoItem => todoItem.Date);
        modelBuilder.Entity<TodoItem>().HasIndex(todoItem => todoItem.User);
    }

}
