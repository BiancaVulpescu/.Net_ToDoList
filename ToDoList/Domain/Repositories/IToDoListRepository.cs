using Domain.Entities;

namespace Domain.Repositories
{
    public interface IToDoListRepository
    {
        Task<IEnumerable<ToDoList>> GetAllAsync();
        Task<ToDoList> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(ToDoList book);
        Task UpdateAsync(ToDoList book);
        Task DeleteAsync(Guid id);
    }
}
