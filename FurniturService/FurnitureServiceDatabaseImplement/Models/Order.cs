using FurnitureServiceBusinessLogic.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace FurnitureServiceDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int FurnitureId { get; set; }
        public int ClientId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Furniture Furnitures { get; set; }
        public virtual Client Clients { get; set; }
    }
}
