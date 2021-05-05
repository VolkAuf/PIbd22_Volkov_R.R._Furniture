using FurnitureServiceBusinessLogic.BindingModels;
using FurnitureServiceBusinessLogic.Interfaces;
using FurnitureServiceBusinessLogic.ViewModels;
using FurnitureServiceDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureServiceDatabaseImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {

        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse, FurnitureServiceDatabase context)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.FullNameOfTheHead = model.FullNameOfTheHead;

            if (warehouse.Id == 0)
            {
                warehouse.DateCreate = DateTime.Now;
                context.Warehouses.Add(warehouse);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var WarehouseComponents = context.WarehouseComponents
                    .Where(rec => rec.WarehouseId == model.Id.Value)
                    .ToList();

                context.WarehouseComponents.RemoveRange(WarehouseComponents
                    .Where(rec => !model.WarehouseComponents.ContainsKey(rec.ComponentId))
                    .ToList());
                context.SaveChanges();

                foreach (var updateComponent in WarehouseComponents)
                {
                    updateComponent.Count = model.WarehouseComponents[updateComponent.ComponentId].Item2;
                    model.WarehouseComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }


            foreach (var WarehouseComponent in model.WarehouseComponents)
            {
                context.WarehouseComponents.Add(new WarehouseComponent
                {
                    WarehouseId = warehouse.Id,
                    ComponentId = WarehouseComponent.Key,
                    Count = WarehouseComponent.Value.Item2
                });
                context.SaveChanges();
            }

            return warehouse;
        }

        public List<WarehouseViewModel> GetFullList()
        {
            using (var context = new FurnitureServiceDatabase())
            {
                return context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .ToList()
                    .Select(rec => new WarehouseViewModel
                    {
                        Id = rec.Id,
                        WarehouseName = rec.WarehouseName,
                        FullNameOfTheHead = rec.FullNameOfTheHead,
                        DateCreate = rec.DateCreate,
                        WarehouseComponents = rec.WarehouseComponents
                            .ToDictionary(recWC => recWC.ComponentId,
                            recWC => (recWC.Component?.ComponentName,
                            recWC.Count))
                    })
                    .ToList();
            }
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new FurnitureServiceDatabase())
            {
                return context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .Where(rec => rec.WarehouseName.Contains(model.WarehouseName))
                    .ToList()
                    .Select(rec => new WarehouseViewModel
                    {
                        Id = rec.Id,
                        WarehouseName = rec.WarehouseName,
                        FullNameOfTheHead = rec.FullNameOfTheHead,
                        DateCreate = rec.DateCreate,
                        WarehouseComponents = rec.WarehouseComponents
                            .ToDictionary(recWC => recWC.ComponentId,
                            recWC => (recWC.Component?.ComponentName,
                            recWC.Count))
                    })
                    .ToList();
            }
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new FurnitureServiceDatabase())
            {
                var Warehouse = context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName ||
                    rec.Id == model.Id);

                return Warehouse != null ?
                    new WarehouseViewModel
                    {
                        Id = Warehouse.Id,
                        WarehouseName = Warehouse.WarehouseName,
                        FullNameOfTheHead = Warehouse.FullNameOfTheHead,
                        DateCreate = Warehouse.DateCreate,
                        WarehouseComponents = Warehouse.WarehouseComponents
                            .ToDictionary(recWC => recWC.ComponentId,
                            recWC => (recWC.Component?.ComponentName,
                            recWC.Count))
                    } :
                    null;
            }
        }

        public void Insert(WarehouseBindingModel model)
        {
            using (var context = new FurnitureServiceDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Warehouse(), context);
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

        public void Update(WarehouseBindingModel model)
        {
            using (var context = new FurnitureServiceDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var warehouse = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

                        if (warehouse == null)
                        {
                            throw new Exception("Склад не найден");
                        }

                        CreateModel(model, warehouse, context);
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

        public void Delete(WarehouseBindingModel model)
        {
            using (var context = new FurnitureServiceDatabase())
            {
                var warehouse = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

                if (warehouse == null)
                {
                    throw new Exception("Склад не найден");
                }

                context.Warehouses.Remove(warehouse);
                context.SaveChanges();
            }
        }

        public bool CheckRemove(Dictionary<int, (string, int)> components, int packagesCount)
        {
            using (var context = new FurnitureServiceDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var warehouseComponent in components)
                        {
                            int count = warehouseComponent.Value.Item2 * packagesCount;
                            IEnumerable<WarehouseComponent> warehouseComponents = context.WarehouseComponents.Where(warehouse => warehouse.ComponentId == warehouseComponent.Key);

                            int accessiblyCount = warehouseComponents.Sum(warehouse => warehouse.Count);

                            if (accessiblyCount < count)
                            {
                                throw new Exception("Недостаточно компонентов!!!");
                            }

                            foreach (WarehouseComponent component in warehouseComponents)
                            {
                                if (component.Count <= count)
                                {
                                    count -= component.Count;
                                    context.WarehouseComponents.Remove(component);
                                    context.SaveChanges();
                                }
                                else
                                {
                                    component.Count -= count;
                                    context.SaveChanges();
                                    count = 0;
                                }

                                if (count == 0)
                                {
                                    break;
                                }
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
