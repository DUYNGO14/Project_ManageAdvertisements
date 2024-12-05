using Domain.Constants;
using MediatR;

namespace Application.MasterData.Queries.GetFloorAndDepartment
{
    public class GetFloorAndDepartmentQuery : IRequest<(List<FloorDeviceResult>, List<DepartmentDeviceResult>)>
    {
        public string[]? DeviceType { get; set; }
    }
}
