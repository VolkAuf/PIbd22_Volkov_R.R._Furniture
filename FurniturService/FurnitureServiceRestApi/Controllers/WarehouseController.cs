using FurnitureServiceBusinessLogic.BindingModels;
using FurnitureServiceBusinessLogic.BusinessLogics;
using FurnitureServiceBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureServiceRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseLogic warehouseLogic;
        private readonly ComponentLogic componentLogic;
        public WarehouseController(WarehouseLogic warehouseLogic, ComponentLogic componentLogic)
        {
            this.warehouseLogic = warehouseLogic;
            this.componentLogic = componentLogic;
        }

        public List<WarehouseViewModel> GetAll() => warehouseLogic.Read(null);

        public List<ComponentViewModel> GetAllComponents() => componentLogic.Read(null);

        [HttpPost]
        public void Create(WarehouseBindingModel model) => warehouseLogic.CreateOrUpdate(model);

        [HttpPost]
        public void Update(WarehouseBindingModel model) => warehouseLogic.CreateOrUpdate(model);

        [HttpPost]
        public void Delete(WarehouseBindingModel model) => warehouseLogic.Delete(model);

        [HttpPost]
        public void AddComponent(AddComponentBindingModel model) => warehouseLogic.AddComponents(model);
    }
}
