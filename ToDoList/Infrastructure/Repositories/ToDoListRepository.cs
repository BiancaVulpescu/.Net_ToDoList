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

            var list = await context.ToDoLists.FindAsync(id);
            if (list != null)
            {
                context.ToDoLists.Remove(list);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"ToDoList with ID {id} not found");
            }
        }
        public async Task<ToDoList> GetByIdAsync(Guid id)
        {
            return await context.ToDoLists.FindAsync(id);
        }
        public async Task UpdateAsync(ToDoList list)
        {
            throw new NotImplementedException();
        }
    }
}
