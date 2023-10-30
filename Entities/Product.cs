using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities{
    [Table("Product")]
    public class Product
    {
        [Key()]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}