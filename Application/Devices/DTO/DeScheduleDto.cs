namespace Application.Devices.DTO
{
    public class DeScheduleDto
    {
        public int Id { get; set; }
        public bool IsDefault { get; set; } = false;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Frequency { get; set; }
        public int TotalDuration { get; set; }
    }
}
