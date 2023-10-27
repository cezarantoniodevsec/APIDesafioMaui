namespace WebApi.Models.Product;

public class UpdateProductRequest
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}
