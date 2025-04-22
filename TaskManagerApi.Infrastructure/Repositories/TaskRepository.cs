using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Domain.Entities;
using TaskManagerApi.Domain.Interfaces;
using TaskManagerApi.Infrastructure.Data;

namespace TaskManagerApi.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository 
    {
        private readonly AppDbContext _context;
        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AppTask>> GetAllAsync()
        {
            return await _context.AppTasks.ToListAsync();
        }

        public async Task<AppTask?> GetByIdAsync(Guid id)
        {
            return await _context.AppTasks.FindAsync(id);
        }

        public async Task CreateAsync(AppTask task)
        {
            task.Id = Guid.NewGuid();
            _context.AppTasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AppTask task)
        {
            _context.AppTasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var task = await GetByIdAsync(id);
            if (task != null)
            {
                _context.AppTasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

    }
}
