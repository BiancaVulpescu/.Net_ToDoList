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
    public class GetToDoListQueryHandler : IRequestHandler<GetToDoListQuery, List<ToDoListDto>>
    {
        private readonly IToDoListRepository repository;
        private readonly IMapper mapper;

        public GetToDoListQueryHandler(IToDoListRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<ToDoListDto>> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
        {
            var lists = await repository.GetAllAsync();
            return mapper.Map<List<ToDoListDto>>(lists);
        }
    }
}
