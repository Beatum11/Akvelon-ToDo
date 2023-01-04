using Microsoft.EntityFrameworkCore;

namespace Akv_API.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<TaskItem> TaskItems { get; set; }

        public DbSet<Project> Projects { get; set; }

    }
}
