using Infrastructure.Persistence;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class ToDoListRepository : IToDoListRepository
    {

        private readonly ApplicationDbContext context;
        public ToDoListRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Guid> AddAsync(ToDoList list)
        {
            await context.ToDoLists.AddAsync(list);
            await context.SaveChangesAsync();
            return list.Id;
        }
        public async Task<IEnumerable<ToDoList>> GetAllAsync()
        {
            return await context.ToDoLists.ToListAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<ToDoList> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task UpdateAsync(ToDoList list)
        {
            throw new NotImplementedException();
        }
    }
}
