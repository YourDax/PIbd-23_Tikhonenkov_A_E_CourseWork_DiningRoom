using DiningRoomContracts.BindingModels;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.StorageContracts;
using DiningRoomContracts.ViewModels;
using DiningRoomDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomDatabaseImplement.Implements
{
	public class OrderStorage : IOrderStorage
	{
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            using var context = new DiningRoomDatabase();

            var element = context.Orders
                .Include(x => x.Product)
                .FirstOrDefault(rec => rec.Id == model.Id);

            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();

                return element.GetViewModel;
            }

            return null;
        }

        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }

            using var context = new DiningRoomDatabase();

            return context.Orders
                    .Include(x=> x.Product)
                    .FirstOrDefault(x => x.Id == model.Id)?.GetViewModel;
        }

        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            using var context = new DiningRoomDatabase();
            
            if (model.DateFrom.HasValue && model.DateTo.HasValue)
            {
                return context.Orders
                    .Where(x => (x.UserId == model.UserId) && (x.DateCreate >= model.DateFrom && x.DateCreate <= model.DateTo))
                    .Include(x => x.Product)
                    .ToList()
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            
            else if (model.Status.HasValue)
            {
                return context.Orders
                    .Where(x => (x.UserId == model.UserId) && (x.Status == model.Status))
                    .Include(x => x.Product)
                    .ToList()
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            
            return context.Orders
                    .Where(x => x.UserId == model.UserId)
                    .Include(x => x.Product)
                    .ToList()
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<OrderViewModel> GetFullList()
        {
            using var context = new DiningRoomDatabase();

            return context.Orders
                .Include(x => x.Product)
                .ToList()
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public OrderViewModel? Insert(OrderBindingModel model)
        {
            var newOrder = Order.Create(model);

            if (newOrder == null)
            {
                return null;
            }

            using var context = new DiningRoomDatabase();
            if (newOrder == null)
            {
                return null;
            }
            context.Orders.Add(newOrder);
            context.SaveChanges();
            return newOrder.GetViewModel;
        }

        public OrderViewModel? Update(OrderBindingModel model)
        {
            using var context = new DiningRoomDatabase();

            var order = context.Orders.FirstOrDefault(x => x.Id == model.Id);
            if (order == null)
            {
                return null;
            }
            order.Update(model);
            context.SaveChanges();
            return order.GetViewModel;
        }
    }
}
