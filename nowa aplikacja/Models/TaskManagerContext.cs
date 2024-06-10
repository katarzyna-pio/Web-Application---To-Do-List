using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace nowa_aplikacja.Models
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
