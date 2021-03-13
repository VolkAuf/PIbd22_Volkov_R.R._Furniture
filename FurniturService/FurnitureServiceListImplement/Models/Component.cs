using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureServiceListImplement.Models
{
    /// <summary>
    /// Компонент, требуемый для изготовления мебели
    /// </summary>
    public class Component
    {
        public int Id { get; set; }
        public string ComponentName { get; set; }
    }
}
