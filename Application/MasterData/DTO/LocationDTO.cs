namespace Application.MasterData.DTO;

public class LocationDTO
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public int Floor { get; set; }
    public string Department { get; set; } = default!;
}
