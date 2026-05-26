namespace BeautySalonExpolorer.DAL.Entities;

public class BusinessCategory
{
    public Guid CategoryId { get; set; }
    public Guid BusinessId { get; set; }

    public Category Category { get; set;} = null!;
    public Business Business { get; set;} = null!;
}