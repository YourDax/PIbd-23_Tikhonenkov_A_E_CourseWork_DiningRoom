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
	//!!!ПОДОБИЕ component
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
                    .Include(x => x.Client)
                    .Include(x => x.Implementer)
                    .FirstOrDefault(x =>
                        (model.Statuses == null || model.Statuses != null && model.Statuses.Contains(x.Status)) &&
                        model.ImplementerId.HasValue && x.ImplementerId == model.ImplementerId ||
                        model.Id.HasValue && x.Id == model.Id
                    )
                    ?.GetViewModel;
        }

        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            if (model.Id.HasValue)
            {
                var result = GetElement(model);
                return result != null ? new() { result } : new();
            }

            using var context = new CarpentryWorkshopDatabase();
            IQueryable<Order>? queryWhere = null;

            if (model.DateFrom.HasValue && model.DateTo.HasValue)
            {
                queryWhere = context.Orders
                    .Where(x => model.DateFrom <= x.DateCreate.Date &&
                                                  x.DateCreate.Date <= model.DateTo);
            }

            else if (model.Statuses != null)
            {
                queryWhere = context.Orders.Where(x => model.Statuses.Contains(x.Status));
            }

            else if (model.ClientId.HasValue)
            {
                queryWhere = context.Orders.Where(x => x.ClientId == model.ClientId);
            }

            else
            {
                return new();
            }

            return queryWhere
                    .Include(x => x.Client)
                    .Include(x => x.Implementer)
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<OrderViewModel> GetFullList()
        {
            using var context = new CarpentryWorkshopDatabase();

            return context.Orders
                .Include(x => x.Wood)
                .Include(x => x.Client)
                .Include(x => x.Implementer)
                .Select(x => x.GetViewModel).ToList();
        }

        public OrderViewModel? Insert(OrderBindingModel model)
        {
            var newOrder = Order.Create(model);

            if (newOrder == null)
            {
                return null;
            }

            using var context = new CarpentryWorkshopDatabase();

            context.Orders.Add(newOrder);
            context.SaveChanges();

            return context.Orders
                          .Include(x => x.Wood)
                          .Include(x => x.Client)
                          .Include(x => x.Implementer)
                          .FirstOrDefault(x => x.Id == newOrder.Id)
                          ?.GetViewModel;
        }

        public OrderViewModel? Update(OrderBindingModel model)
        {
            using var context = new CarpentryWorkshopDatabase();

            var order = context.Orders
                .Include(x => x.Wood)
                .Include(x => x.Client)
                .Include(x => x.Implementer)
                .FirstOrDefault(x => x.Id == model.Id);

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
