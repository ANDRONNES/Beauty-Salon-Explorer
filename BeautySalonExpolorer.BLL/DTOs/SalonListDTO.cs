namespace BeautySalonExpolorer.BLL.DTOs;

public class SalonListDTO
{
    public Guid SalonId { get; set; }
    public string Name { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string District { get; set; } = null!;

    public decimal? Rating { get; set; }
    public string ImageUrl { get; set; } = null!;
    public List<string> Categories { get; set; } = [];
}