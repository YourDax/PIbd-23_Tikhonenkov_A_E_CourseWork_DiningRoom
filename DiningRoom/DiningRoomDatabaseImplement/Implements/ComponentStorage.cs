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
            if (string.IsNullOrEmpty(model.ComponentName))
            {
                return new();
            }
            using var context = new DiningRoomDatabase();
            return context.Components
                    .Where(x => x.ComponentName.Contains(model.ComponentName))
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
        public List<ReportComponentOrderViewModel> GetComponentsOrders(List<ComponentSearchModel> Models)
        {
            using var Context = new DiningRoomDatabase();

            return Context.Components
                .Include(x => x.ProductComponents)
                    .ThenInclude(x => x.Product)
                    .ThenInclude(x => x.Order)
                .Where(x =>
                    Models.Select(x => x.Id).Contains(x.Id)  // Компонент, указанный пользователем,
                    && x.ProductComponents.Any(y => y.Product.Order != null))  
                .ToList()
                .Select(x => new ReportComponentOrderViewModel
                {
                    ComponentId = x.Id,
                    ComponentName = x.ComponentName,
                    ComponentCost = x.Cost,
                    Orders = x.ProductComponents
                        .Select(y => (y.Count, y.Product.ProductName, y.Product.Cost, y.Product.Order.DateCreate))
                        .ToList(),
                })
                .ToList();
        }

        public List<ReportComponentByDateViewModel> GetComponentsByDate(ReportBindingModel ReportModel, UserSearchModel UserModel)
        {
            using var Context = new DiningRoomDatabase();

            return Context.Components
                .Where(c => c.UserId == UserModel.Id)
                .Include(x => x.ProductComponents)
                    .ThenInclude(pc => pc.Product)
                .Include(c => c.DrinkComponents)
                    .ThenInclude(ac => ac.Drink)
                        .ThenInclude(a => a.Cards.Where(r => r.DateCardCreate >= ReportModel.DateFrom && r.DateCardCreate <= ReportModel.DateTo))
                .ToList()
                .SelectMany(c => c.DrinkComponents
                    .SelectMany(ac => ac.Drink.Cards, (ac, r) => new { ac, r })
                    .SelectMany(temp => c.ProductComponents, (temp, pc) => new { temp.ac, temp.r, pc })
                    .Select(temp => new ReportComponentByDateViewModel
                    {
                        ComponentId = c.Id,
                        ComponentName = c.ComponentName,
                        ComponentCost = c.Cost,
                        ProductId = temp.pc.Product.Id,
                        ProductName = temp.pc.Product.ProductName,
                        ProductPrice = temp.pc.Product.Cost,
                        CardId = temp.r.Id,
                        CardName = temp.r.CardName,
                    }))
                .ToList();
        }



    }
}