using FurnitureServiceBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureServiceBusinessLogic.HelperModels
{
    public class ExcelInfoWarehouse
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportWarehouseComponentsViewModel> WarehouseComponents { get; set; }
    }
}
