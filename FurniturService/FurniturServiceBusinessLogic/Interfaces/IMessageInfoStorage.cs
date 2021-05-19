using FurnitureServiceBusinessLogic.BindingModels;
using FurnitureServiceBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureServiceBusinessLogic.Interfaces
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();
        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);
        void Insert(MessageInfoBindingModel model);
    }
}
