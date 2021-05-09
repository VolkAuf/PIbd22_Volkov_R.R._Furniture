using FurnitureServiceBusinessLogic.BindingModels;
using FurnitureServiceBusinessLogic.Interfaces;
using FurnitureServiceBusinessLogic.ViewModels;
using FurnitureServiceDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FurnitureServiceDatabaseImplement.Implements
{
    public class FurnitureStorage : IFurnitureStorage
    {
        public List<FurnitureViewModel> GetFullList()
        {
            using (var context = new FurnitureServiceDatabase())
            {
                return context.Furnitures
                .Include(rec => rec.FurnitureComponents)
                .ThenInclude(rec => rec.Component)
                .ToList()
                .Select(rec => new FurnitureViewModel
                {
                    Id = rec.Id,
                    FurnitureName = rec.FurnitureName,
                    Price = rec.Price,
                    FurnitureComponents = rec.FurnitureComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
                })
                .ToList();
            }
        }
        public List<FurnitureViewModel> GetFilteredList(FurnitureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FurnitureServiceDatabase())
            {
                return context.Furnitures
                .Include(rec => rec.FurnitureComponents)
                .ThenInclude(rec => rec.Component)
                .Where(rec => rec.FurnitureName.Contains(model.FurnitureName))
                .ToList()
                .Select(rec => new FurnitureViewModel
                {
                    Id = rec.Id,
                    FurnitureName = rec.FurnitureName,
                    Price = rec.Price,
                    FurnitureComponents = rec.FurnitureComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
                })
                .ToList();
            }
        }
        public FurnitureViewModel GetElement(FurnitureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FurnitureServiceDatabase())
            {
                var furniture = context.Furnitures
                .Include(rec => rec.FurnitureComponents)
                .ThenInclude(rec => rec.Component)
                .FirstOrDefault(rec => rec.FurnitureName == model.FurnitureName || rec.Id == model.Id);
                return furniture != null ?
                new FurnitureViewModel
                {
                    Id = furniture.Id,
                    FurnitureName = furniture.FurnitureName,
                    Price = furniture.Price,
                    FurnitureComponents = furniture.FurnitureComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
                } :
                null;
            }
        }
        public void Insert(FurnitureBindingModel model)
        {
            using (var context = new FurnitureServiceDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Furniture furniture = new Furniture
                        {
                            FurnitureName = model.FurnitureName,
                            Price = model.Price
                        };
                        context.Furnitures.Add(furniture);
                        context.SaveChanges();
                        CreateModel(model, furniture, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(FurnitureBindingModel model)
        {
            using (var context = new FurnitureServiceDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Furnitures.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        element.FurnitureName = model.FurnitureName;
                        element.Price = model.Price;
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(FurnitureBindingModel model)
        {
            using (var context = new FurnitureServiceDatabase())
            {
                Furniture element = context.Furnitures.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Furnitures.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Furniture CreateModel(FurnitureBindingModel model, Furniture furniture, FurnitureServiceDatabase context)
        {
            if (model.Id.HasValue)
            {
                var furnitureComponents = context.FurnitureComponents.Where(rec => rec.FurnitureId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.FurnitureComponents.RemoveRange(furnitureComponents.Where(rec => !model.FurnitureComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in furnitureComponents)
                {
                    updateComponent.Count = model.FurnitureComponents[updateComponent.ComponentId].Item2;
                    model.FurnitureComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var fc in model.FurnitureComponents)
            {
                context.FurnitureComponents.Add(new FurnitureComponent
                {
                    FurnitureId = furniture.Id,
                    ComponentId = fc.Key,
                    Count = fc.Value.Item2
                });
                context.SaveChanges();
            }
            return furniture;
        }
    }
}
