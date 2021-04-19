using FurnitureServiceBusinessLogic.Enums;
using FurnitureServiceFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace FurnitureServiceFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string FurnitureFileName = "Furniture.xml";
        private readonly string WarehouseFileName = "Warehouse.xml";
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Furniture> Furnitures { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Furnitures = LoadFurnitures();
            Warehouses = LoadWarehouses();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveFurnitures();
            SaveWarehouses();
        }
        private List<Component> LoadComponents()
        {
            List<Component> list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);
                List<XElement> xElements = xDocument.Root.Elements("Component").ToList();
                foreach (XElement elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            // прописать логику
            List<Order> list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                List<XElement> xElements = xDocument.Root.Elements("Order").ToList();
                foreach (XElement elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FurnitureId = Convert.ToInt32(elem.Element("FurnitureId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                   elem.Element("Status").Value),
                        DateCreate =
                   Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement =
                   string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                   Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Furniture> LoadFurnitures()
        {
            List<Furniture> list = new List<Furniture>();
            if (File.Exists(FurnitureFileName))
            {
                XDocument xDocument = XDocument.Load(FurnitureFileName);
                List<XElement> xElements = xDocument.Root.Elements("Furniture").ToList();
                foreach (XElement elem in xElements)
                {
                    Dictionary<int, int> furnitureComp = new Dictionary<int, int>();
                    foreach (XElement component in elem.Element("FurnitureComponents").Elements("FurnitureComponent").ToList())
                    {
                        furnitureComp.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Furniture
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        FurnitureName = elem.Element("FurnitureName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        FurnitureComponents = furnitureComp
                    });
                }
            }
            return list;
        }
        private List<Warehouse> LoadWarehouses()
        {
            List<Warehouse> list = new List<Warehouse>();

            if (File.Exists(WarehouseFileName))
            {
                XDocument xDocument = XDocument.Load(WarehouseFileName);

                List<XElement> xElements = xDocument.Root.Elements("Warehouse").ToList();

                foreach (XElement warehouse in xElements)
                {
                    Dictionary<int, int> warehouseComponents = new Dictionary<int, int>();

                    foreach (XElement component in warehouse.Element("WarehouseComponents").Elements("WarehouseComponent").ToList())
                    {
                        warehouseComponents.Add(Convert.ToInt32(component.Element("Key").Value), Convert.ToInt32(component.Element("Value").Value));
                    }

                    list.Add(new Warehouse
                    {
                        Id = Convert.ToInt32(warehouse.Attribute("Id").Value),
                        WarehouseName = warehouse.Element("WarehouseName").Value,
                        FullNameOfTheHead = warehouse.Element("FullNameOfTheHead").Value,
                        DateCreate = DateTime.ParseExact(warehouse.Element("DateCreate").Value, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                        WarehouseComponents = warehouseComponents
                    });
                }
            }
            return list;
        }
        private void SaveComponents()
        {
            if (Components != null)
            {
                XElement xElement = new XElement("Components");
                foreach (Component component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }
        private void SaveOrders()
        {
            // прописать логику
            if (Orders != null)
            {
                XElement xElement = new XElement("Orders");
                foreach (Order order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("FurnitureId", order.FurnitureId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveFurnitures()
        {
            if (Furnitures != null)
            {
                XElement xElement = new XElement("Furnitures");
                foreach (Furniture furniture in Furnitures)
                {
                    XElement compElement = new XElement("FurnitureComponents");
                    foreach (KeyValuePair<int, int> component in furniture.FurnitureComponents)
                    {
                        compElement.Add(new XElement("FurnitureComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Furniture",
                    new XAttribute("Id", furniture.Id),
                    new XElement("FurnitureName", furniture.FurnitureName),
                    new XElement("Price", furniture.Price),
                    compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(FurnitureFileName);
            }
        }
        private void SaveWarehouses()
        {
            if (Warehouses != null)
            {
                var xElement = new XElement("Warehouses");

                foreach (var warehouse in Warehouses)
                {
                    var compElement = new XElement("WarehouseComponents");

                    foreach (var component in warehouse.WarehouseComponents)
                    {
                        compElement.Add(new XElement("WarehouseComponent",
                            new XElement("Key", component.Key),
                            new XElement("Value", component.Value)));
                    }

                    xElement.Add(new XElement("Warehouse",
                        new XAttribute("Id", warehouse.Id),
                        new XElement("WarehouseName", warehouse.WarehouseName),
                        new XElement("FullNameOfTheHead", warehouse.FullNameOfTheHead),
                        new XElement("DateCreate", warehouse.DateCreate.ToString()),
                        compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(WarehouseFileName);
            }
        }
    }
}

