using FurnitureServiceDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FurnitureServiceDatabaseImplement
{
    public class FurnitureServiceDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FurnitureServiceDatabase6H;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Furniture> Furnitures { set; get; }
        public virtual DbSet<FurnitureComponent> FurnitureComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Warehouse> Warehouses { set; get; }
        public virtual DbSet<WarehouseComponent> WarehouseComponents { set; get; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Implementer> Implementers { get; set; }
    }
}
