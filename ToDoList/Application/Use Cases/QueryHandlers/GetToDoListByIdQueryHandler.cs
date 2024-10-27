using Application.DTOs;
using Application.Use_Cases.Queries;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Use_Cases.QueryHandlers
{
    public class GetToDoListByIdQueryHandler : IRequestHandler<GetToDoListByIdQuery, ToDoListDto>
    {
        private readonly IToDoListRepository repository;
        private readonly IMapper mapper;

        public GetToDoListByIdQueryHandler(IToDoListRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ToDoListDto> Handle(GetToDoListByIdQuery request, CancellationToken cancellationToken)
        {
            var list = await repository.GetByIdAsync(request.Id);
            if (list == null)
            {
                throw new KeyNotFoundException($"ToDo list with ID {request.Id} not found.");
            }
            return mapper.Map<ToDoListDto>(list);
        }
    }
}