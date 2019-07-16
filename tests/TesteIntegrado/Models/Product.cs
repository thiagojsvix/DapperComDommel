namespace TesteIntegrado.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        // The foreign key to Categories table
        public int CategoryId { get; set; }

        // The navigation property
        public Category Category { get; set; }
    }
}
