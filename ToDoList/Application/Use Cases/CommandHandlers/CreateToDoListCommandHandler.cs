using Application.Use_Cases.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers
{
    public class CreateToDoListCommandHandler : IRequestHandler<CreateToDoListCommand, Guid>
    {
        private readonly IToDoListRepository repository;
        private readonly IMapper mapper;

        public CreateToDoListCommandHandler(IToDoListRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Guid> Handle(CreateToDoListCommand request, CancellationToken cancellationToken)
        {
            var list = mapper.Map<ToDoList>(request);
            return await repository.AddAsync(list);
        }
    }
}
