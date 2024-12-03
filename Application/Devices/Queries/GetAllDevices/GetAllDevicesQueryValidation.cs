using Domain.Entities;
using FluentValidation;

namespace Application.Devices.Queries.GetAllDevices;

public class GetAllDevicesQueryValidation : AbstractValidator<GetAllDevicesQuery> 
{
    private string[] allowSortByColumnNames = [nameof(Device.DeviceName), nameof(Device.DeviceType.Name), nameof(Device.DeviceType.Size)];
    public GetAllDevicesQueryValidation()
    {
        RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1).WithMessage("Page number >= 1");
        RuleFor(r => r.PageSize).GreaterThanOrEqualTo(1).WithMessage("Page PageSize >= 1");
        RuleFor(r => r.SortBy)
            .Must(value => allowSortByColumnNames.Contains(value))
            .When(q => q.SortBy != null)
            .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowSortByColumnNames)}]"); ;
    }
}
