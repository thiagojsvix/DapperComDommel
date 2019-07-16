namespace TesteIntegrado.Models
{
    public class OrderLine
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string Line { get; set; }
    }
}