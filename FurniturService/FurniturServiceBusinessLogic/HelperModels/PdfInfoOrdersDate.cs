using FurnitureServiceBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureServiceBusinessLogic.HelperModels
{
    public class PdfInfoOrdersDate
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportOrdersAllDatesViewModel> Orders { get; set; }
    }
}
