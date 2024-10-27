using Application.DTOs;
using MediatR;

namespace Application.Use_Cases.Queries
{
    public class GetToDoListByIdQuery : IRequest<ToDoListDto>
    {
        public Guid Id { get; set; }
    }
}
