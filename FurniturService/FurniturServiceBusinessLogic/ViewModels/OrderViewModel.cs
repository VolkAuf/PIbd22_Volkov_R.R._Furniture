using FurnitureServiceBusinessLogic.Attributes;
using FurnitureServiceBusinessLogic.Enums;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace FurnitureServiceBusinessLogic.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    [DataContract]
    public class OrderViewModel
    {
        [Column(title: "Номер", width: 50)]
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int FurnitureId { get; set; }

        [DataMember]
        public int? ImplementerId { get; set; }

        [Column(title: "Исполнитель", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        [DisplayName("Исполнитель")]
        public string ImplementerFIO { get; set; }

        [Column(title: "Клиент", width:150)]
        [DataMember]
        [DisplayName("Клиент")]
        public string ClientFIO { get; set; }

        [Column(title: "Мебель", width: 100)]
        [DataMember]
        [DisplayName("Мебель")]
        public string FurnitureName { get; set; }

        [Column(title: "Количество", width: 50)]
        [DataMember]
        [DisplayName("Количество")]
        public int Count { get; set; }

        [Column(title: "Сумма", format: "c2", width: 50)]
        [DataMember]
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }

        [Column(title: "Статус", width: 100)]
        [DataMember]
        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }

        [Column(title: "Дата создания", format: "dd/MM/yyyy", width: 50)]
        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        [Column(title: "Дата выполнения", format: "dd/MM/yyyy", width: 50)]
        [DataMember]
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}
