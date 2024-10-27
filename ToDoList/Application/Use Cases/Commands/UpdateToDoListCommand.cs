using MediatR;

namespace Application.Use_Cases.Commands
{
    public class UpdateToDoListCommand : CreateToDoListCommand, IRequest
    {
        public Guid Id { get; set; }
    }
}
