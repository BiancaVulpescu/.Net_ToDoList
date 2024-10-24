using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
