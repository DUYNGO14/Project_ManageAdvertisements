using Application.Contents.DTO;
using Application.Devices.DTO;

namespace Application.Schedules.DTO
{
    public class SchedulesDto
    {
        public int Id { get; set; }
        public bool IsDefault { get; set; } = false;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Frequency { get; set; } // Số lần phát trong khung giờ 
        public int TotalDuration { get; set; } // Tổng thời gian phát (giây) = Frequency * Media.Duration
        public ContentDto? Contentdto { get; set; }
        public DeviceDto? Devicedto { get; set; }
    }
}
