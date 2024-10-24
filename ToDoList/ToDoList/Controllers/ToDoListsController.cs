using MediatR;
using Microsoft.AspNetCore.Http;
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

   
    }
}
