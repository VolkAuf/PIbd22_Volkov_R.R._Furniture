using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureServiceDatabaseImplement.Models
{
    public class Furniture
    {
        public int Id { get; set; }
        [Required]
        public string FurnitureName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("FurnitureId")]
        public virtual List<FurnitureComponent> FurnitureComponents { get; set; }
        [ForeignKey("FurnitureId")]
        public virtual List<Order> Orders { get; set; }
    }
}
