using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureServiceFileImplement.Models
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class Furniture
    {
        public int Id { get; set; }
        public string FurnitureName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> FurnitureComponents { get; set; }
    }
}
