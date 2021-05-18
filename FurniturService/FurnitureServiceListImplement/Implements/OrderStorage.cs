using FurnitureServiceBusinessLogic.BindingModels;
using FurnitureServiceBusinessLogic.Enums;
using FurnitureServiceBusinessLogic.Interfaces;
using FurnitureServiceBusinessLogic.ViewModels;
using FurnitureServiceListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureServiceListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton source;
        public OrderStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetFullList()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                result.Add(CreateModel(order));
            }
            return result;
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if ((!model.DateFrom.HasValue && !model.DateTo.HasValue && order.DateCreate.Date == model.DateCreate.Date)
                     || (model.DateFrom.HasValue && model.DateTo.HasValue && order.DateCreate.Date >= model.DateFrom.Value.Date && order.DateCreate.Date <= model.DateTo.Value.Date)
                     || (model.ClientId.HasValue && order.ClientId == model.ClientId)
                     || (model.FreeOrders.HasValue && model.FreeOrders.Value && !order.ImplementerId.HasValue)
                     || (model.ImplementerId.HasValue && order.ImplementerId == model.ImplementerId && order.Status == OrderStatus.Выполняется))
                {
                    result.Add(CreateModel(order));
                }
            }
            return result;
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id || order.FurnitureId == model.FurnitureId)
                {
                    return CreateModel(order);
                }
            }
            return null;
        }
        public void Insert(OrderBindingModel model)
        {
            Order tempOrder = new Order { Id = 1 };
            foreach (var order in source.Orders)
            {
                if (order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = order.Id + 1;
                }
            }
            source.Orders.Add(CreateModel(model, tempOrder));
        }
        public void Update(OrderBindingModel model)
        {
            Order temporder = null;
            foreach (var order in source.Orders)
            {
                if (order.Id == model.Id)
                {
                    temporder = order;
                }
            }
            if (temporder == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, temporder);
        }
        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id.Value)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.FurnitureId = model.FurnitureId;
            order.Count = model.Count;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.Status = model.Status;
            order.Sum = model.Sum;
            order.ClientId = (int) model.ClientId;
            order.ImplementerId = model.ImplementerId;
            return order;
        }
        private OrderViewModel CreateModel(Order order)
        {
            string furnitureName = null;
            foreach (var or in source.Furnitures)
            {
                if(or.Id == order.FurnitureId)
                {
                    furnitureName = or.FurnitureName;
                }
            }
            string clientFIO = null;
            foreach (var or in source.Clients)
            {
                if (or.Id == order.ClientId)
                {
                    clientFIO = or.ClientFIO;
                }
            }
            string implementerFIO = null;
            foreach (var implementer in source.Implementers)
            {
                if (implementer.Id == order.ImplementerId)
                {
                    implementerFIO = implementer.ImplementerFIO;
                }
            }
            return new OrderViewModel
            {
                Id = order.Id,
                FurnitureId = order.FurnitureId,
                FurnitureName = furnitureName,
                ClientId = order.ClientId,
                ClientFIO = clientFIO,
                ImplementerId = order.ImplementerId,
                ImplementerFIO = implementerFIO,
                Count = order.Count,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = order.Status,
                Sum = order.Sum
            };
        }
    }
}
