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
    public class ClientController : ControllerBase
    {
        private readonly ClientLogic _logic;
        public ClientController(ClientLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public ClientViewModel Login(string login, string password) {
           var client = _logic.Read(new ClientBindingModel { Email = login, Password = password });
           return (client != null && client.Count > 0) ? client[0] : null;
        }
            
        [HttpPost]
        public void Register(ClientBindingModel model) => _logic.CreateOrUpdate(model);
        [HttpPost]
        public void UpdateData(ClientBindingModel model) => _logic.CreateOrUpdate(model);
    }
    
}
