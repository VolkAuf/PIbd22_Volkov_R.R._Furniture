﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureServiceBusinessLogic.ViewModels
{
    public class ReportOrdersDateViewModel
    {
        public DateTime Date { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}
