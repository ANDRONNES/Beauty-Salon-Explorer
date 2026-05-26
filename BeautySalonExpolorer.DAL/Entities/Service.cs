namespace BeautySalonExpolorer.DAL.Entities;

public class Service
{
    public Guid ServiceId { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }

    public ICollection<BusinessService> Businesses { get; set;} = [];
}