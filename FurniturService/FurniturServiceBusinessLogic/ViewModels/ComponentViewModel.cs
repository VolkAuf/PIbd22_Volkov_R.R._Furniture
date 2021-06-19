using FurnitureServiceBusinessLogic.Attributes;
using System.ComponentModel;

namespace FurnitureServiceBusinessLogic.ViewModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class ComponentViewModel
    {
        [Column(title: "Номер", width: 50)]
        public int Id { get; set; }

        [Column(title: "Компонент", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DisplayName("Название компонента")]
        public string ComponentName { get; set; }
    }
}
