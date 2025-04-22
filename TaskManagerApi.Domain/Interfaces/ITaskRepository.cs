using TaskManagerApi.Domain.Entities;

namespace TaskManagerApi.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<AppTask>> GetAllAsync();
        Task<AppTask?> GetByIdAsync(Guid id);
        Task CreateAsync (AppTask task);
        Task UpdateAsync (AppTask task);
        Task DeleteAsync(Guid id);
    }
}
