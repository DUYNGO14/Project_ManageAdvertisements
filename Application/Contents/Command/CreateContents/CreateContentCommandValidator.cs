using FluentValidation;

namespace Application.Contents.Command.CreateContents;

public class CreateContentCommandValidator : AbstractValidator<CreateContentCommand>
{
    public CreateContentCommandValidator()
    {
        // Title validation: not empty, min length 5
        RuleFor(x => x.Title)
            .NotNull().WithMessage("Title is required.")
            .NotEmpty().WithMessage("Title is required.")
            .MinimumLength(5).WithMessage("Title must be at least 5 characters.");

        // Description validation: not empty, min length 10
        RuleFor(x => x.Description)
            .NotNull().WithMessage("Description is required.")
            .NotEmpty().WithMessage("Description is required.")
            .MinimumLength(10).WithMessage("Description must be at least 10 characters.");

    }
}
