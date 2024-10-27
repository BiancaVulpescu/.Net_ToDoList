using Domain.Entities;

namespace Domain.Repositories
{
    public interface IToDoListRepository
    {
        Task<IEnumerable<ToDoList>> GetAllAsync();
        Task<ToDoList> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(ToDoList tdl);
        Task UpdateAsync(ToDoList tdl);
        Task DeleteAsync(Guid id);
    }
}
