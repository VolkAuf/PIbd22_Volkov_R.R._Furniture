using System.Collections.Generic;
using System.ComponentModel;

namespace FurnitureServiceBusinessLogic.ViewModels
{
    public class FurnitureViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название мебели")]
        public string FurnitureName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> FurnitureComponents { get; set; }
    }
}
