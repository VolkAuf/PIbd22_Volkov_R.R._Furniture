using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FurnitureServiceBusinessLogic.BindingModels
{
    /// <summary>
    /// Данные от клиента, для создания заказа
    /// </summary>
    public class CreateOrderBindingModel
    {
        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int FurnitureId { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Sum { get; set; }
    }
}
