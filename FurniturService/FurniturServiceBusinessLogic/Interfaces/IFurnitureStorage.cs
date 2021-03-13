using FurnitureServiceBusinessLogic.ViewModels;
using FurnitureServiceBusinessLogic.BindingModels;
using System.Collections.Generic;

namespace FurnitureServiceBusinessLogic.Interfaces
{
    public interface IFurnitureStorage
    {
        List<FurnitureViewModel> GetFullList();
        List<FurnitureViewModel> GetFilteredList(FurnitureBindingModel model);
        FurnitureViewModel GetElement(FurnitureBindingModel model);
        void Insert(FurnitureBindingModel model);
        void Update(FurnitureBindingModel model);
        void Delete(FurnitureBindingModel model);
    }
}
