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
            using var Context = new DiningRoomDatabase();

            return Context.Products
                .Include(x => x.Order)
                .Include(x => x.Components)
                    .ThenInclude(x => x.Component)
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public List<ProductViewModel> GetFilteredList(ProductSearchModel model)
		{
            using var context = new DiningRoomDatabase();
            var query = context.Products.AsQueryable();

            if (model.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == model.UserId.Value);
            }

            return query.Select(x => x.GetViewModel).ToList();
        }

        public ProductViewModel? GetElement(ProductSearchModel Model)
        {
            using var Context = new DiningRoomDatabase();

            // ProductName is unique
            if (!string.IsNullOrEmpty(Model.ProductName))
            {
                return Context.Products
                    .Include(x => x.Order)
                    .Include(x => x.Components)
                        .ThenInclude(x => x.Component)
                    .FirstOrDefault(x => x.ProductName == Model.ProductName)?
                    .GetViewModel;
            }

            return Context.Products
                .Include(x => x.Order)
                .Include(x => x.Components)
                    .ThenInclude(x => x.Component)
                .FirstOrDefault(x => x.Id == Model.Id)?
                .GetViewModel;
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