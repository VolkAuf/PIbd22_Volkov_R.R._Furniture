using FurnitureServiceBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace FurnitureServiceBusinessLogic.ViewModels
{
    [DataContract]
    public class WarehouseViewModel
    {
        [Column(title: "Номер", width:50)]
        [DataMember]
        [DisplayName("Номер")]
        public int Id { get; set; }

        [Column(title: "Название склада", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        [DisplayName("Название склада")]
        public string WarehouseName { get; set; }

        [Column(title: "ФИО ответственного", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        [DisplayName("ФИО ответственного")]
        public string FullNameOfTheHead { get; set; }

        [Column(title: "Дата создания", format: "dd/MM/yyyy", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
