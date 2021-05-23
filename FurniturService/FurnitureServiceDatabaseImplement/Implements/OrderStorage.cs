﻿using FurnitureServiceBusinessLogic.BindingModels;
using FurnitureServiceBusinessLogic.Interfaces;
using FurnitureServiceBusinessLogic.ViewModels;
using FurnitureServiceDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FurnitureServiceDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (FurnitureServiceDatabase context = new FurnitureServiceDatabase())
            {
                return context.Orders
                .Include(rec => rec.Furnitures)
                .Include(rec => rec.Clients)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    FurnitureId = rec.FurnitureId,
                    ClientId = rec.ClientId,
                    FurnitureName = rec.Furnitures.FurnitureName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    ClientFIO = rec.Clients.ClientFIO
                })
                .ToList();
            }
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (FurnitureServiceDatabase context = new FurnitureServiceDatabase())
            {
                return context.Orders
                .Include(rec => rec.Furnitures)
                .Include(rec => rec.Clients)
                .Where(rec => (rec.FurnitureId == model.FurnitureId) || (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date) ||
                (rec.ClientId == model.ClientId))
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    FurnitureId = rec.FurnitureId,
                    ClientId = rec.ClientId,
                    FurnitureName = rec.Furnitures.FurnitureName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    ClientFIO = rec.Clients.ClientFIO,
                }) 
                .ToList();
            }
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (FurnitureServiceDatabase context = new FurnitureServiceDatabase())
            {
                Order order = context.Orders
                .Include(rec => rec.Clients)
                .Include(rec => rec.Furnitures)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    FurnitureId = order.FurnitureId,
                    ClientId = order.ClientId,
                    FurnitureName = order.Furnitures.FurnitureName,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                    ClientFIO = order.Clients.ClientFIO
                } :
                null;
            }
        }
        public void Insert(OrderBindingModel model)
        {
            using (FurnitureServiceDatabase context = new FurnitureServiceDatabase())
            {
                Order order = new Order
                {
                    FurnitureId = model.FurnitureId,
                    ClientId = (int) model.ClientId,
                    Count = model.Count,
                    Sum = model.Sum,
                    Status = model.Status,
                    DateCreate = model.DateCreate,
                    DateImplement = model.DateImplement,
                };
                context.Orders.Add(order);
                context.SaveChanges();
                CreateModel(model, order);
                context.SaveChanges();
            }
        }
        public void Update(OrderBindingModel model)
        {
            using (FurnitureServiceDatabase context = new FurnitureServiceDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                element.FurnitureId = model.FurnitureId;
                element.ClientId = (int) model.ClientId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (FurnitureServiceDatabase context = new FurnitureServiceDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            if (model == null)
            {
                return null;
            }

            using (FurnitureServiceDatabase context = new FurnitureServiceDatabase())
            {
                Furniture element = context.Furnitures.FirstOrDefault(rec => rec.Id == model.FurnitureId);
                if (element != null)
                {
                    if (element.Orders == null)
                    {
                        element.Orders = new List<Order>();
                    }
                    element.Orders.Add(order);
                    context.Furnitures.Update(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
            return order;
        }
    }
}
