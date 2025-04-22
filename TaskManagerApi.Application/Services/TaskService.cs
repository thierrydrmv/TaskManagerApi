using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApi.Domain.Entities;
using TaskManagerApi.Domain.Interfaces;

namespace TaskManagerApi.Application.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<AppTask>> ListAsync() => await _taskRepository.GetAllAsync();
        public async Task<AppTask?> GetByIdAsync(Guid id) => await _taskRepository.GetByIdAsync(id);
        public async Task CreateAsync(AppTask task) => await _taskRepository.CreateAsync(task);
        public async Task UpdateAsync(AppTask task) => await _taskRepository.UpdateAsync(task);
        public async Task DeleteAsync(Guid id) => await _taskRepository.DeleteAsync(id);
    }
}
