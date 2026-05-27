namespace BeautySalonExpolorer.DAL.Entities;

public class SalonService
{
    public Guid ServiceId { get; set; }
    public Guid SalonId { get; set; }
    public decimal? Price { get; set; }

    public Service Service { get; set; } = null!;
    public Salon Salon { get; set; } = null!;
}