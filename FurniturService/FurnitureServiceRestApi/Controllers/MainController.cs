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
    public class MainController : ControllerBase
    {
        private readonly OrderLogic _order;
        private readonly FurnitureLogic _furniture;
        private readonly OrderLogic _main;
        public MainController(OrderLogic order, FurnitureLogic furniture, OrderLogic main)
        {
            _order = order;
            _main = main;
            _furniture = furniture;
        }
        [HttpGet]
        public List<FurnitureViewModel> GetFurnitureList() => _furniture.Read(null)?.ToList();
        [HttpGet]
        public FurnitureViewModel GetFurniture(int furnitureId) => _furniture.Read(new FurnitureBindingModel { Id = furnitureId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
    }
}
