namespace BeautySalonExpolorer.BLL.DTOs;

public class SalonDTO
{
    public Guid SalonId { get; set; }
    public string Name {get; set;} = null!;
    public string Street {get; set;} = null!;
    public string District {get; set;} = null!;
    public string? Phone {get; set;}
    public string? Website {get; set;}
    public decimal? Rating {get; set;}
    public int? ReviewsCount {get; set;}
    public string? LocationUrl {get; set;}
    public List<string> Categories { get; set; } = [];
}