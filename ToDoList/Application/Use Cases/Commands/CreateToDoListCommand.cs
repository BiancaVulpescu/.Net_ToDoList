using MediatR;

namespace Application.Use_Cases.Commands
{
    public class CreateToDoListCommand : IRequest<Guid>
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime DueDate { get; set; }
    }
}
