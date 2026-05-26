namespace BeautySalonExpolorer.DAL.Entities;

public class BusinessService
{
    public Guid ServiceId { get; set; }
    public Guid BusinessId { get; set; }
    public required decimal Price { get; set; }

    public Service Service { get; set;} = null!;
    public Business Business { get; set;} = null!;
}