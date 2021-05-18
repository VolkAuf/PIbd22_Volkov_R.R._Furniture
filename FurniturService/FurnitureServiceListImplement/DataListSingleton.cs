using FurnitureServiceListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureServiceListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Furnitures> Furnitures { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        public List<MessageInfo> MessageInfos { get; set; }
        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            Furnitures = new List<Furnitures>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
            MessageInfos = new List<MessageInfo>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
