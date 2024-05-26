using DiningRoomContracts.BindingModels;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.StorageContracts;
using DiningRoomContracts.ViewModels;
using DiningRoomDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace DiningRoomDatabaseImplement.Implements
{
    public class DrinkStorage : IDrinkStorage
    {
		public List<DrinkViewModel> GetFullList()
		{
			using var context = new DiningRoomDatabase();
			return context.Drinks
                    .Include(x => x.Card)
                    .Include(x => x.Components)
					.ThenInclude(x => x.Component)
					.ToList()
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<DrinkViewModel> GetFilteredList(DrinkSearchModel model)
		{
            using var context = new DiningRoomDatabase();
            var query = context.Drinks.AsQueryable();

            if (model.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == model.UserId.Value);
            }

            return query.Select(x => x.GetViewModel).ToList();
        }

		public DrinkViewModel? GetElement(DrinkSearchModel model)
		{
			if (string.IsNullOrEmpty(model.DrinkName) && !model.Id.HasValue)
			{
				return null;
			}
			using var context = new DiningRoomDatabase();
			return context.Drinks
                .Include(x => x.Card)
                .Include(x => x.Components)
				.ThenInclude(x => x.Component)
				.FirstOrDefault(x => (!string.IsNullOrEmpty(model.DrinkName) && x.DrinkName == model.DrinkName) ||
								(model.Id.HasValue && x.Id == model.Id))
				?.GetViewModel;
		}

		public DrinkViewModel? Insert(DrinkBindingModel model)
		{
			using var context = new DiningRoomDatabase();
			var newDrink = Drink.Create(context, model);
			if (newDrink == null)
			{
				return null;
			}
			context.Drinks.Add(newDrink);
			context.SaveChanges();
			return newDrink.GetViewModel;
		}

		public DrinkViewModel? Update(DrinkBindingModel model)
		{
			using var context = new DiningRoomDatabase();
			using var transaction = context.Database.BeginTransaction();
			try
			{
				var Drink = context.Drinks.FirstOrDefault(rec => rec.Id == model.Id);
				if (Drink == null)
				{
					return null;
				}
				Drink.Update(model);
				context.SaveChanges();
				Drink.UpdateComponents(context, model);
				transaction.Commit();
				return Drink.GetViewModel;
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		public DrinkViewModel? Delete(DrinkBindingModel model)
		{
			using var context = new DiningRoomDatabase();
			var element = context.Drinks
				.Include(x => x.Components)
				.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Drinks.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}
    }
}