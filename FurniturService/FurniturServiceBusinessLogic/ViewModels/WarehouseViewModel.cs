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
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Название")]
        public string WarehouseName { get; set; }

        [DataMember]
        [DisplayName("ФИО ответственного")]
        public string FullNameOfTheHead { get; set; }

        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
