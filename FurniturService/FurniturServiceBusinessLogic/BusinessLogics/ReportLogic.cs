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
        private readonly IWarehouseStorage _warehouseStorage;
        public ReportLogic(IFurnitureStorage furnitureStorage, IComponentStorage componentStorage, IOrderStorage orderStorage, IWarehouseStorage warehouseStorage)
        {
            _furnitureStorage = furnitureStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
            _warehouseStorage = warehouseStorage;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportFurnitureComponentViewModel> GetFurnitureComponent()
        {
            List<FurnitureViewModel> furnitures = _furnitureStorage.GetFullList();
            List<ReportFurnitureComponentViewModel> list = new List<ReportFurnitureComponentViewModel>();
            foreach (FurnitureViewModel furniture in furnitures)
            {
                var record = new ReportFurnitureComponentViewModel
                {
                    FurnitureName = furniture.FurnitureName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in furniture.FurnitureComponents)
                {
                        record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                        record.TotalCount += component.Value.Item2;
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
        public List<ReportWarehouseComponentsViewModel> GetWarehouseComponents()
        {
            var warehouses = _warehouseStorage.GetFullList();
            var records = new List<ReportWarehouseComponentsViewModel>();

            foreach (var warehouse in warehouses)
            {
                var record = new ReportWarehouseComponentsViewModel
                {
                    WarehouseName = warehouse.WarehouseName,
                    TotalCount = 0,
                    Components = new List<Tuple<string, int>>(),
                };

                foreach (var component in warehouse.WarehouseComponents)
                {
                    record.Components.Add(new Tuple<string, int>(
                        component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                records.Add(record);
            }
            return records;
        }
        public List<ReportOrdersDateViewModel> GetOrdersDate()
        {
            return _orderStorage.GetFullList()
                .GroupBy(order => order.DateCreate.ToShortDateString())
                .Select(rec => new ReportOrdersDateViewModel
                {
                    Date = Convert.ToDateTime(rec.Key),
                    Count = rec.Count(),
                    Sum = rec.Sum(order => order.Sum)
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
        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateWarehouseDoc(new WordInfoWarehouse
            {
                FileName = model.FileName,
                Title = "Список складов",
                Warehouses = _warehouseStorage.GetFullList()
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
        public void SaveWarehouseComponentsToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateWarehouseDoc(new ExcelInfoWarehouse
            {
                FileName = model.FileName,
                Title = "Список складов",
                WarehouseComponents = GetWarehouseComponents()
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
        public void SaveOrdersDateToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateSummaryOrderInfoDoc(new PdfInfoOrdersDate
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrdersDate()
            });
        }
    }
}
