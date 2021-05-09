using FurnitureServiceBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureServiceBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }
        public string FurnitureName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
    }
}
