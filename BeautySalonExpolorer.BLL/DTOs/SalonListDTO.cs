namespace BeautySalonExpolorer.BLL.DTOs;

public class SalonListDTO
{
    public Guid SalonId { get; set; }
    public string Name { get; set; } = null!;
    public string ShortAddress { get; set; } = null!;
    public decimal? Rating { get; set; }
    public List<string> Categories { get; set; } = [];
}