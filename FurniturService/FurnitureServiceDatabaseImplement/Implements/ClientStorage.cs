using FurnitureServiceBusinessLogic.BindingModels;
using FurnitureServiceBusinessLogic.Interfaces;
using FurnitureServiceBusinessLogic.ViewModels;
using FurnitureServiceDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureServiceDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public void Delete(ClientBindingModel model)
        {
            using (FurnitureServiceDatabase context = new FurnitureServiceDatabase())
            {
                Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Clients.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (FurnitureServiceDatabase context = new FurnitureServiceDatabase())
            {
                Client client = context.Clients
                .Include(rec => rec.Orders)
                .FirstOrDefault(rec => rec.Email == model.Email || rec.Id == model.Id);
                return client != null ?
                new ClientViewModel
                {
                    Id = client.Id,
                    ClientFIO = client.ClientFIO,
                    Password = client.Password,
                    Email = client.Email
                } :
                null;
            }
        }

        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FurnitureServiceDatabase())
            {
                return context.Clients
                .Include(rec => rec.Orders)
                .Where(rec => rec.Password.Equals(model.Password) && rec.Email.Equals(model.Email))
                .Select(rec => new ClientViewModel
                {
                    Id = rec.Id,
                    ClientFIO = rec.ClientFIO,
                    Email = rec.Email,
                    Password = rec.Password,
                })
                .ToList();
            }
        }

        public List<ClientViewModel> GetFullList()
        {
            using (FurnitureServiceDatabase context = new FurnitureServiceDatabase())
            {
                return context.Clients
                .Select(rec => new ClientViewModel
                {
                    ClientFIO = rec.ClientFIO,
                    Id = rec.Id,
                    Password = rec.Password,
                    Email = rec.Email,
                })
                .ToList();
            }
        }

        public void Insert(ClientBindingModel model)
        {
            using (FurnitureServiceDatabase context = new FurnitureServiceDatabase())
            {
                Client client = new Client
                {
                    ClientFIO = model.ClientFIO,
                    Email = model.Email,
                    Password = model.Password,
                };
                context.Clients.Add(client);
                context.SaveChanges();
                CreateModel(model, client);
                context.SaveChanges();
            }
        }

        public void Update(ClientBindingModel model)
        {
            using (FurnitureServiceDatabase context = new FurnitureServiceDatabase())
            {
                Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                element.ClientFIO = model.ClientFIO;
                element.Email = model.Email;
                element.Password = model.Password;
                
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public Client CreateModel(ClientBindingModel model, Client client)
        {
            if (model == null)
            {
                return null;
            }

            return client;
        }
    }
}
