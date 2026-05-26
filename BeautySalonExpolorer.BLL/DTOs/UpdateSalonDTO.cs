namespace BeautySalonExpolorer.BLL.DTOs;
public class UpdateSalonDTO
{
    public Guid SalonId { get; set; }
    public string Name {get; set;} = null!;
    public string Street {get; set;} = null!;
    public string District {get; set;} = null!;
    public string? Phone {get; set;}
    public string? Website {get; set;}
    public string? LocationUrl {get; set;}
    public List<string> Categories { get; set; } = [];
}