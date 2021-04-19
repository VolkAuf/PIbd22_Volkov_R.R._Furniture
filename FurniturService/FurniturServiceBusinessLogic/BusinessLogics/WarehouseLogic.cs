using FurnitureServiceBusinessLogic.BindingModels;
using FurnitureServiceBusinessLogic.Interfaces;
using FurnitureServiceBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureServiceBusinessLogic.BusinessLogics
{
    public class WarehouseLogic
    {
        private readonly IWarehouseStorage _warehouseStorage;
        private readonly IComponentStorage _componentStorage;

        public WarehouseLogic(IWarehouseStorage warehouseStorage, IComponentStorage componentStorage)
        {
            _warehouseStorage = warehouseStorage;
            _componentStorage = componentStorage;
        }

        public List<WarehouseViewModel> Read(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return _warehouseStorage.GetFullList();
            }

            if (model.Id.HasValue)
            {
                return new List<WarehouseViewModel> { _warehouseStorage.GetElement(model) };
            }

            return _warehouseStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(WarehouseBindingModel model)
        {
            var element = _warehouseStorage.GetElement(
                new WarehouseBindingModel
                {
                    Id = model.Id
                });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть склад с таким названием");
            }

            if (model.Id.HasValue)
            {
                _warehouseStorage.Update(model);
            }
            else
            {
                _warehouseStorage.Insert(model);
            }
        }

        public void Delete(WarehouseBindingModel model)
        {
            var element = _warehouseStorage.GetElement(
                new WarehouseBindingModel
                {
                    Id = model.Id
                });

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            _warehouseStorage.Delete(model);
        }

        public void AddComponents(AddComponentBindingModel model)
        {
            var warehouse = _warehouseStorage.GetElement(new WarehouseBindingModel
            {
                Id = model.WarehouseId
            });

            var component = _componentStorage.GetElement(new ComponentBindingModel
            {
                Id = model.ComponentId
            });

            if (warehouse == null)
            {
                throw new Exception("Склад не найден");
            }

            if (component == null)
            {
                throw new Exception("Компонент не найден");
            }

            Dictionary<int, (string, int)> warehouseComponents = warehouse.WarehouseComponents;

            if (warehouseComponents.ContainsKey(model.ComponentId))
            {
                warehouseComponents[model.ComponentId] = (warehouseComponents[model.ComponentId].Item1,
                    warehouseComponents[model.ComponentId].Item2 + model.Count);
            }
            else
            {
                warehouseComponents.Add(model.ComponentId, (component.ComponentName, model.Count));
            }


            _warehouseStorage.Update(new WarehouseBindingModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                FullNameOfTheHead = warehouse.FullNameOfTheHead,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouseComponents
            });
        }
    }
}
