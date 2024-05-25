using DiningRoomContracts.BindingModels;
using DiningRoomContracts.ViewModels;
using DiningRoomDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace DiningRoomDatabaseImplement.Models
{
	public class Product : IProductModel
	{
		public int Id { get; set; }

		[Required]
		public string ProductName { get; set; } = string.Empty;

        [Required]
		public double Cost { get; set; }
        private Dictionary<int, (IComponentModel, int)>? _productComponents;

        [NotMapped]
        public Dictionary<int, (IComponentModel, int)> ProductComponents
        {
            get
            {
                if (_productComponents == null)
                {
                    _productComponents = Components.ToDictionary(
                        ProdComp => ProdComp.ComponentId,
                        ProdComp => (ProdComp.Component as IComponentModel, ProdComp.Count)
                    );
                }

                return _productComponents;
            }
        }
        [ForeignKey("ProductId")]
        public virtual List<ProductComponent> Components { get; set; } = new();
        [ForeignKey("ProductId")]
        public virtual List<Order> Order { get; set; } = new();
		public static Product Create(DiningRoomDatabase Context, ProductBindingModel Model)
		{
			return new()
			{
				Id = Model.Id,
                ProductName = Model.ProductName,
				Cost = Model.Cost,
				Components = Model.ProductComponents.Select(x => new ProductComponent
				{
					Component = Context.Components.First(y => y.Id == x.Key),
					Count = x.Value.Item2
				}).ToList(),
			};
		}
        public void Update(ProductBindingModel model)
        {
            ProductName = model.ProductName;
            Cost = model.Cost;
        }
        public ProductViewModel GetViewModel => new()
        {
            Id = Id,
            ProductName = ProductName,
            Cost = Cost,
            ProductComponents = ProductComponents
        };
        public void UpdateComponents(DiningRoomDatabase context, ProductBindingModel model)
        {
            var productComponents = context.ProductComponents.Where(rec => rec.ProductId == model.Id).ToList();
            if (productComponents != null && productComponents.Count > 0)
            { // удалили те, которых нет в модели
                context.ProductComponents.RemoveRange(productComponents.Where(rec => !model.ProductComponents.ContainsKey(rec.ComponentId)));
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in productComponents)
                {
                    updateComponent.Count = model.ProductComponents[updateComponent.ComponentId].Item2;
                    model.ProductComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            var product = context.Products.First(x => x.Id == Id);
            foreach (var pc in model.ProductComponents)
            {
                context.ProductComponents.Add(new ProductComponent
                {
                    Product = product,
                    Component = context.Components.First(x => x.Id == pc.Key),
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            _productComponents = null;
        }
    }
}
