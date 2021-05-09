using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FurnitureServiceDatabaseImplement.Models
{
    public class Furniture
    {
        public int Id { get; set; }
        [Required]
        public string FurnitureName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual List<FurnitureComponent> FurnitureComponents { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
