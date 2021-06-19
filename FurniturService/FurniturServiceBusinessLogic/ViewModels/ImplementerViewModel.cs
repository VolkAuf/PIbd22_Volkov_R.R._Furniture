using FurnitureServiceBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FurnitureServiceBusinessLogic.ViewModels
{
    /// <summary>
    /// Исполнитель, выполняющий заказы
    /// </summary>
    public class ImplementerViewModel
    {
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }

        [Column(title: "Исполнитель", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DisplayName("ФИО исполнителя")]
        public string ImplementerFIO { get; set; }

        [Column(title: "Время на заказ", width: 100)]
        [DisplayName("Время на заказ")]
        public int WorkingTime { get; set; }

        [Column(title: "Время на перерыв", width: 100)]
        [DisplayName("Время на перерыв")]
        public int PauseTime { get; set; }
    }
}
