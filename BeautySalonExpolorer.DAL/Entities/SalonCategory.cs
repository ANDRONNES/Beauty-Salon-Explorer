namespace BeautySalonExpolorer.DAL.Entities;

public class SalonCategory
{
    public Guid CategoryId { get; set; }
    public Guid SalonId { get; set; }

    public Category Category { get; set; } = null!;
    public Salon Salon { get; set; } = null!;
}