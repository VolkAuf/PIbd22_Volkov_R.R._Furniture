using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureServiceDatabaseImplement.Models
{
    /// <summary>
    /// Компонент, требуемый для изготовления мебели
    /// </summary>
    public class Component
    {
        public int Id { get; set; }
        [Required]
        public string ComponentName { get; set; }
        [ForeignKey("ComponentId")]
        public virtual List<FurnitureComponent> FurnitureComponents { get; set; }
    }
}
