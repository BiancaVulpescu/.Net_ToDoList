using MediatR;

namespace Application.Use_Cases.Commands
{
    public class DeleteToDoListCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
