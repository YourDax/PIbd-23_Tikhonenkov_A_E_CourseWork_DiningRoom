using DiningRoomContracts.BindingModels;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.StorageContracts;
using DiningRoomContracts.ViewModels;
using DiningRoomDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace DiningRoomDatabaseImplement.Implements
{
    public class ProductStorage : IProductStorage
    {
		public List<ProductViewModel> GetFullList()
		{
			using var context = new DiningRoomDatabase();
			return context.Products
					.Include(x => x.Components)
					.ThenInclude(x => x.Component)
					.ToList()
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<ProductViewModel> GetFilteredList(ProductSearchModel model)
		{
			if (string.IsNullOrEmpty(model.ProductName))
			{
				return new();
			}
			using var context = new DiningRoomDatabase();
			return context.Products
					.Include(x => x.Components)
					.ThenInclude(x => x.Component)
					.Where(x => x.ProductName.Contains(model.ProductName))
					.ToList()
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public ProductViewModel? GetElement(ProductSearchModel model)
		{
			if (string.IsNullOrEmpty(model.ProductName) && !model.Id.HasValue)
			{
				return null;
			}
			using var context = new DiningRoomDatabase();
			return context.Products
				.Include(x => x.Components)
				.ThenInclude(x => x.Component)
				.FirstOrDefault(x => (!string.IsNullOrEmpty(model.ProductName) && x.ProductName == model.ProductName) ||
								(model.Id.HasValue && x.Id == model.Id))
				?.GetViewModel;
		}

		public ProductViewModel? Insert(ProductBindingModel model)
		{
			using var context = new DiningRoomDatabase();
			var newProduct = Product.Create(context, model);
			if (newProduct == null)
			{
				return null;
			}
			context.Products.Add(newProduct);
			context.SaveChanges();
			return newProduct.GetViewModel;
		}

		public ProductViewModel? Update(ProductBindingModel model)
		{
			using var context = new DiningRoomDatabase();
			using var transaction = context.Database.BeginTransaction();
			try
			{
				var Product = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
				if (Product == null)
				{
					return null;
				}
				Product.Update(model);
				context.SaveChanges();
				Product.UpdateComponents(context, model);
				transaction.Commit();
				return Product.GetViewModel;
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		public ProductViewModel? Delete(ProductBindingModel model)
		{
			using var context = new DiningRoomDatabase();
			var element = context.Products
				.Include(x => x.Components)
				.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Products.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}
	}
}