namespace WebApi.Models.Product;

public class UpdateProductRequest
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
}
