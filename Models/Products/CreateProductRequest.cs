namespace WebApi.Models.Product;

public class CreateProductRequest
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
}