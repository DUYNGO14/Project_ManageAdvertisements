using Domain.Entities;
using FluentValidation;

namespace Application.Contents.Queries.GetAllContents;

public class GetAllContentQueryValidator : AbstractValidator<GetAllContentQuery>
{
    private string[] allowSortByColumnNames = [nameof(Content.Title), nameof(Content.CreatedAt)];
    public GetAllContentQueryValidator()
    {
        RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1).WithMessage("Page number >= 1");
        RuleFor(r => r.PageSize).GreaterThanOrEqualTo(1).WithMessage("Page number >= 1");
        RuleFor(r => r.SortBy)
            .Must(value => allowSortByColumnNames.Contains(value))
            .When(q => q.SortBy != null)
            .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowSortByColumnNames)}]"); ;
    }
}
