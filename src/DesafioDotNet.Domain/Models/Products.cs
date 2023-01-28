namespace DesafioDotNet.Domain.Models;

public class Products : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Value { get; set; }
    public string Brand { get; set; }
    public string Image { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
