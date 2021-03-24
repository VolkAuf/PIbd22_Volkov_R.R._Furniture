using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureServiceBusinessLogic.ViewModels
{
    public class ReportFurnitureComponentViewModel
    {
        public string FurnitureName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
    }
}
