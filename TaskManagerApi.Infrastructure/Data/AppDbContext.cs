using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Domain.Entities;

namespace TaskManagerApi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AppTask> AppTasks => Set<AppTask>();
    }
}
