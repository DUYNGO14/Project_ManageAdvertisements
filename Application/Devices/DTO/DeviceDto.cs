using Application.Schedules.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Devices.DTO
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public string DeviceName { get; set; } = default!;
        public string DeviceType { get; set; } = default!;
        public string Size { get; set; } = default!;
        public string Resolution { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<SchedulesDto> SchedulesDtos { get; set; } = new();
        public string Department { get; set; } = default!;
        public int Floor { get; set; } = default!;
    }
}
