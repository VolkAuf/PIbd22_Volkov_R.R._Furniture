using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FurnitureServiceBusinessLogic.ViewModels
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string WarehouseName { get; set; }

        [DisplayName("ФИО ответственного")]
        public string FullNameOfTheHead { get; set; }

        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
