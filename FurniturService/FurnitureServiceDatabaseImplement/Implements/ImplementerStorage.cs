using FurnitureServiceBusinessLogic.BindingModels;
using FurnitureServiceBusinessLogic.Interfaces;
using FurnitureServiceBusinessLogic.ViewModels;
using FurnitureServiceDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureServiceDatabaseImplement.Implements
{
    public class ImplementerStorage : IImplementerStorage
    {
        public List<ImplementerViewModel> GetFullList()
        {
            using (var context = new FurnitureServiceDatabase())
            {
                return context.Implementers.Select(rec => new ImplementerViewModel
                {
                    Id = rec.Id,
                    ImplementerFIO = rec.ImplementerFIO,
                    WorkingTime = rec.WorkingTime,
                    PauseTime = rec.PauseTime
                })
                .ToList();
            }
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FurnitureServiceDatabase())
            {
                return context.Implementers
                .Where(rec => rec.ImplementerFIO == model.ImplementerFIO)
                .Select(rec => new ImplementerViewModel
                {
                    Id = rec.Id,
                    ImplementerFIO = rec.ImplementerFIO,
                    WorkingTime = rec.WorkingTime,
                    PauseTime = rec.PauseTime
                })
                .ToList();
            }
        }

        public ImplementerViewModel GetElement(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FurnitureServiceDatabase())
            {
                var implementer = context.Implementers
                .FirstOrDefault(rec => rec.Id == model.Id);
                return implementer != null ?
                new ImplementerViewModel
                {
                    Id = implementer.Id,
                    ImplementerFIO = implementer.ImplementerFIO,
                    WorkingTime = implementer.WorkingTime,
                    PauseTime = implementer.PauseTime
                } :
                null;
            }
        }

        public void Insert(ImplementerBindingModel model)
        {
            using (var context = new FurnitureServiceDatabase())
            {
                context.Implementers.Add(CreateModel(model, new Implementer()));
                context.SaveChanges();
            }
        }

        public void Update(ImplementerBindingModel model)
        {
            using (var context = new FurnitureServiceDatabase())
            {
                var implementer = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
                if (implementer == null)
                {
                    throw new Exception("Такого исполнителя не существует");
                }
                CreateModel(model, implementer);
                context.SaveChanges();
            }
        }

        public void Delete(ImplementerBindingModel model)
        {
            using (var context = new FurnitureServiceDatabase())
            {
                Implementer implementer = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
                if (implementer != null)
                {
                    context.Implementers.Remove(implementer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Такого исполнителя не существует");
                }
            }
        }

        private Implementer CreateModel(ImplementerBindingModel model, Implementer implementer)
        {
            implementer.ImplementerFIO = model.ImplementerFIO;
            implementer.WorkingTime = model.WorkingTime;
            implementer.PauseTime = model.PauseTime;
            return implementer;
        }
    }
}
