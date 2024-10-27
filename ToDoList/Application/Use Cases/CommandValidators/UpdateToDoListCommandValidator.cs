using Application.Use_Cases.Commands;
using FluentValidation;

namespace Application.Use_Cases.CommandValidators
{
    public class UpdateToDoListCommandValidator : AbstractValidator<UpdateToDoListCommand>
    {
        public UpdateToDoListCommandValidator()
        {
            RuleFor(tdl => tdl.Id).NotEmpty().Must(BeValidGuid).WithMessage("'{PropertyName}' must be a valid Guid!");
            RuleFor(tdl => tdl.Description).NotEmpty().MaximumLength(200);
            RuleFor(tdl => tdl.IsDone).NotEmpty();
            RuleFor(tdl => tdl.DueDate).NotEmpty();
        }

        private bool BeValidGuid(Guid guid)
        {
            return Guid.TryParse(guid.ToString(), out _);
        }
    }
}
