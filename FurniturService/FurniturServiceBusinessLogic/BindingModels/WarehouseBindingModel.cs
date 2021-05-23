using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FurnitureServiceBusinessLogic.BindingModels
{
    [DataContract]
    public class WarehouseBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]

        public string WarehouseName { get; set; }
        [DataMember]

        public string FullNameOfTheHead { get; set; }
        [DataMember]

        public DateTime DateCreate { get; set; }
        [DataMember]

        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
