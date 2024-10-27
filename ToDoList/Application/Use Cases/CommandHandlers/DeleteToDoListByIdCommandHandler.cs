using Application.Use_Cases.Commands;
using Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Use_Cases.CommandHandlers
{
    public class DeleteToDoListCommandHandler : IRequestHandler<DeleteToDoListCommand, bool>
    {
        private readonly IToDoListRepository repository;

        public DeleteToDoListCommandHandler(IToDoListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(DeleteToDoListCommand request, CancellationToken cancellationToken)
        {
            var toDoList = await repository.GetByIdAsync(request.Id);
            if (toDoList == null)
            {
                return false;
            }

            await repository.DeleteAsync(toDoList.Id);
            return true;
        }
    }
}
