using FurnitureServiceBusinessLogic.Attributes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace FurnitureServiceBusinessLogic.ViewModels
{
    [DataContract]
    public class FurnitureViewModel
    {
        [Column(title: "Номер", width: 50)]
        [DataMember]
        public int Id { get; set; }

        [Column(title: "Мебель", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        [DisplayName("Название мебели")]
        public string FurnitureName { get; set; }

        [Column(title: "Цена", format: "c2", width: 100)]
        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> FurnitureComponents { get; set; }
    }
}
