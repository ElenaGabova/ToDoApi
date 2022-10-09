using DatabaseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject.Context
{
    /// <summary>
    /// Databse context class
    /// </summary>
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// ToDo items DbSet
        /// </summary>
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}