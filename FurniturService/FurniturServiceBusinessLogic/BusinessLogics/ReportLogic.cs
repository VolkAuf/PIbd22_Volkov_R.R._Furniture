using FurnitureServiceBusinessLogic.BindingModels;
using FurnitureServiceBusinessLogic.HelperModels;
using FurnitureServiceBusinessLogic.Interfaces;
using FurnitureServiceBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FurnitureServiceBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly IFurnitureStorage _furnitureStorage;
        private readonly IOrderStorage _orderStorage;
        public ReportLogic(IFurnitureStorage furnitureStorage, IComponentStorage componentStorage, IOrderStorage orderStorage)
        {
            _furnitureStorage = furnitureStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportFurnitureComponentViewModel> GetFurnitureComponent()
        {
            List<FurnitureViewModel> furnitures = _furnitureStorage.GetFullList();
            List<ComponentViewModel> components = _componentStorage.GetFullList();
            List<ReportFurnitureComponentViewModel> list = new List<ReportFurnitureComponentViewModel>();
            foreach (FurnitureViewModel furniture in furnitures)
            {
                var record = new ReportFurnitureComponentViewModel
                {
                    FurnitureName = furniture.FurnitureName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (ComponentViewModel component in components)
                {
                    if (furniture.FurnitureComponents.ContainsKey(component.Id))
                    {
                        record.Components.Add(new Tuple<string, int>(component.ComponentName, furniture.FurnitureComponents[component.Id].Item2));
                        record.TotalCount += furniture.FurnitureComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel { DateFrom = model.DateFrom, DateTo = model.DateTo })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                FurnitureName = x.FurnitureName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
            .ToList();
        }
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Furnitures = _furnitureStorage.GetFullList()
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveFurnitureComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список изделий с компонентами",
                FurnitureComponents = GetFurnitureComponent()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}
