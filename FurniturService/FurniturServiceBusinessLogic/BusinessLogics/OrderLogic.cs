using FurnitureServiceBusinessLogic.BindingModels;
using FurnitureServiceBusinessLogic.Enums;
using FurnitureServiceBusinessLogic.Interfaces;
using FurnitureServiceBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace FurnitureServiceBusinessLogic.BusinessLogics
{
    public class OrderLogic
    {
        private readonly IOrderStorage _orderStorage;
        private readonly IFurnitureStorage _furnitureStorage;
        private readonly IWarehouseStorage _warehouseStorage;
        private readonly object locker = new object();
        public OrderLogic(IOrderStorage orderStorage, IFurnitureStorage furnitureStorage, IWarehouseStorage warehouseStorage)
        {
            _orderStorage = orderStorage;
            _furnitureStorage = furnitureStorage;
            _warehouseStorage = warehouseStorage;
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            if (model == null)
            {
                return _orderStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<OrderViewModel> { _orderStorage.GetElement(model) };
            }
            return _orderStorage.GetFilteredList(model);
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            _orderStorage.Insert(new OrderBindingModel
            {
                FurnitureId = model.FurnitureId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                OrderViewModel order = _orderStorage.GetElement(new OrderBindingModel
                {
                    Id = model.OrderId
                });
                if (order == null)
                {
                    throw new Exception("Не найден заказ");
                }
                if (order.Status != OrderStatus.Принят && order.Status != OrderStatus.Требуются_материалы)
                {
                    throw new Exception("Заказ еще не принят");
                }

                var updateBindingModel = new OrderBindingModel
                {
                    Id = order.Id,
                    FurnitureId = order.FurnitureId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    ClientId = order.ClientId
                };

                if (!_warehouseStorage.CheckRemove(_furnitureStorage.GetElement
                    (new FurnitureBindingModel { Id = order.FurnitureId }).FurnitureComponents, order.Count))
                {
                    updateBindingModel.Status = OrderStatus.Требуются_материалы;
                }
                else
                {
                    updateBindingModel.DateImplement = DateTime.Now;
                    updateBindingModel.Status = OrderStatus.Выполняется;
                    updateBindingModel.ImplementerId = model.ImplementerId;
                }

                _orderStorage.Update(updateBindingModel);
            }
        }
        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                FurnitureId = order.FurnitureId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Готов
            });
        }
        public void PayOrder(ChangeStatusBindingModel model)
        {
            // продумать логику
            var order = _orderStorage.GetElement(new OrderBindingModel { Id = model.OrderId });
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            _orderStorage.Update(new OrderBindingModel
            {
                Id = order.Id,
                FurnitureId = order.FurnitureId,
                ClientId = order.ClientId,
                ImplementerId = order.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
        }
    }
}
