using Application.DTOs;
using Application.Use_Cases.Commands;
using Application.Use_Cases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ToDoListsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateToDoList(CreateToDoListCommand command)
        {
            var id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetToDoListById), new { Id = id }, command);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ToDoListDto>> GetToDoListById(Guid id)
        {
            return await mediator.Send(new GetToDoListByIdQuery { Id = id });
        }


    }
}
