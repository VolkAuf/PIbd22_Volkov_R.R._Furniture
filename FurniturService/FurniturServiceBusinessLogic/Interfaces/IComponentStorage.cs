using FurnitureServiceBusinessLogic.ViewModels;
using FurnitureServiceBusinessLogic.BindingModels;
using System.Collections.Generic;

namespace FurnitureServiceBusinessLogic.Interfaces
{
    public interface IComponentStorage
    {
        List<ComponentViewModel> GetFullList();
        List<ComponentViewModel> GetFilteredList(ComponentBindingModel model);
        ComponentViewModel GetElement(ComponentBindingModel model);
        void Insert(ComponentBindingModel model);
        void Update(ComponentBindingModel model);
        void Delete(ComponentBindingModel model);
    }
}
