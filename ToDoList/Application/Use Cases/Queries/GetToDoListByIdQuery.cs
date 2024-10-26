using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Use_Cases.Queries
{
    public class GetToDoListByIdQuery : IRequest<ToDoListDto>
    {
        public Guid Id { get; set; }
    }
}
