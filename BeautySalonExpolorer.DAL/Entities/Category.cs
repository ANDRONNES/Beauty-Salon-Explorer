namespace BeautySalonExpolorer.DAL.Entities;

public class Category
{
    public Guid CategoryId { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }

    public ICollection<SalonCategory> Salons { get; set; } = [];
}