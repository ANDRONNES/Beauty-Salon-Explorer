namespace BeautySalonExpolorer.DAL.Entities;

public class Salon
{
    public Guid SalonId {get; set; } = Guid.NewGuid();
    public required string Name {get; set;}
    public required string Street {get; set;}
    public required string District {get; set;}
    public string? Phone {get; set;}
    public string? Website {get; set;}
    public decimal? Rating {get; set;}
    public int? ReviewsCount {get; set;}
    public string? LocationUrl {get; set;}

    public ICollection<SalonCategory> Categories {get; set;} = [];
    public ICollection<SalonService> Services {get; set;} = [];
}