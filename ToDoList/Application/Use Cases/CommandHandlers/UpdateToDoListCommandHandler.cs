using Application.Use_Cases.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers
{
    public class UpdateToDoListCommandHandler : IRequestHandler<UpdateToDoListCommand>
    {
        private readonly IToDoListRepository repository;
        private readonly IMapper mapper;

        public UpdateToDoListCommandHandler(IToDoListRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public Task Handle(UpdateToDoListCommand request, CancellationToken cancellationToken)
        {
            var tdl = mapper.Map<ToDoList>(request);
            return repository.UpdateAsync(tdl);
        }
    }
}
