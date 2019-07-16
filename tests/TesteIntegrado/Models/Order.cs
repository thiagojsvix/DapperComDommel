using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteIntegrado.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(OrderLine.OrderId))]
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}