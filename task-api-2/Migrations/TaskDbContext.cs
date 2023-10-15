using task_api_2.Models;
using Microsoft.EntityFrameworkCore;
using TaskModel = task_api_2.Models.Task;

namespace task_api_2.Migrations
{
    public class TaskDbContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }

        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskModel>(entity =>
            {
                entity.HasKey(e => e.TaskId);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Completed).IsRequired();
            });
        }
    }
}
