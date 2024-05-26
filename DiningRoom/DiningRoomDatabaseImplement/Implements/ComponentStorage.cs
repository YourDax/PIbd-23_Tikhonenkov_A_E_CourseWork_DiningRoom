using DiningRoomContracts.BindingModels;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.StorageContracts;
using DiningRoomContracts.ViewModels;
using DiningRoomDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace DiningRoomDatabaseImplement.Implements
{
    public class ComponentStorage : IComponentStorage
    {
        //
        public List<ComponentViewModel> GetFullList()
        {
            using var context = new DiningRoomDatabase();
            return context.Components
                    .Select(x => x.GetViewModel)
                    .ToList();
        }
        //
        public List<ComponentViewModel> GetFilteredList(ComponentSearchModel model)
        {
            using var context = new DiningRoomDatabase();
            var query = context.Components.AsQueryable();

            if (model.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == model.UserId.Value);
            }

            return query
                    .Select(x => x.GetViewModel)
                    .ToList();
        }
        //
        public ComponentViewModel? GetElement(ComponentSearchModel Model)
        {
            using var Context = new DiningRoomDatabase();

            // ComponentName is unique
            if (!string.IsNullOrEmpty(Model.ComponentName))
            {
                return Context.Components
                    .FirstOrDefault(x => x.ComponentName == Model.ComponentName)?
                    .GetViewModel;
            }

            return Context.Components
                .FirstOrDefault(x => x.Id == Model.Id)?
                .GetViewModel;
        }
        //
        public ComponentViewModel? Insert(ComponentBindingModel model)
        {
            using var Context = new DiningRoomDatabase();

            var NewComponent = Component.Create(model);
            Context.Components.Add(NewComponent);
            Context.SaveChanges();

            return NewComponent.GetViewModel;
        }

        public ComponentViewModel? Update(ComponentBindingModel model)
        {
            using var Context = new DiningRoomDatabase();

            var ExistingComponent = Context.Components.FirstOrDefault(x => x.Id == model.Id);
            if (ExistingComponent == null)
            {
                return null;
            }

            ExistingComponent.Update(model);
            Context.SaveChanges();

            return ExistingComponent.GetViewModel;
        }

        public ComponentViewModel? Delete(ComponentBindingModel model)
        {
            using var Context = new DiningRoomDatabase();

            var ExistingComponent = Context.Components.FirstOrDefault(x => x.Id == model.Id);
            if (ExistingComponent == null)
            {
                return null;
            }

            Context.Components.Remove(ExistingComponent);
            Context.SaveChanges();

            return ExistingComponent.GetViewModel;
        }
        public List<ReportComponentOrderViewModel> GetComponentsOrders(List<ComponentSearchModel> models)
        {
            using var context = new DiningRoomDatabase();

            return context.Components
                .Include(x => x.ProductComponents)
                    .ThenInclude(x => x.Product)
                    .ThenInclude(x => x.Order)
                .Where(x => models.Select(m => m.Id).Contains(x.Id)
                    && x.ProductComponents.Any(pc => pc.Product.Order.Any()))
                .SelectMany(x => x.ProductComponents
                    .SelectMany(pc => pc.Product.Order
                        .Select(order => new ReportComponentOrderViewModel
                        {
                            ComponentName = x.ComponentName,
                            OrderName = order.Name, // Assuming Order has a property OrderName
                            ProductCount = order.Count
                        })))
                .ToList();
        }



        public List<ReportComponentByDateViewModel> GetComponentsByDate(ReportBindingModel ReportModel)
        {
            using var Context = new DiningRoomDatabase();

            return Context.Cards
                .Where(card => card.DateCardCreate >= ReportModel.DateFrom && card.DateCardCreate <= ReportModel.DateTo)
                .Include(card => card.Drinks)
                    .ThenInclude(d => d.Components)
                        .ThenInclude(dc => dc.Component)
                            .ThenInclude(c => c.ProductComponents)
                                .ThenInclude(pc => pc.Product)
                .ToList()
                .SelectMany(card => card.Drinks
            .SelectMany(d => d.Components.SelectMany(dc => dc.Component.ProductComponents.Select(pc => new ReportComponentByDateViewModel
            {
                ComponentId = pc.ComponentId,
                ComponentName = dc.Component.ComponentName,
                ComponentCost = dc.Component.Cost,
                ProductId = pc.ProductId,
                ProductName = pc.Product.ProductName,
                ProductPrice = pc.Product.Cost,
                CardId = card.Id,
                CardName = card.CardName,
            }))))
            .ToList();
        }
    }
}