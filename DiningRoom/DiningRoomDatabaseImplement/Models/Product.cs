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
        public int UserId { get; set; }
        public User User { get; set; }

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
                UserId = Model.UserId,
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
            // Получаем список текущих записей ProductComponents для продукта
            var productComponents = context.ProductComponents.Where(rec => rec.ProductId == model.Id).ToList();

            // Удаляем все текущие записи
            if (productComponents != null && productComponents.Count > 0)
            {
                context.ProductComponents.RemoveRange(productComponents);
                context.SaveChanges();
            }

            // Получаем продукт по его Id
            var product = context.Products.First(x => x.Id == model.Id);

            // Добавляем новые записи ProductComponents из модели
            foreach (var pc in model.ProductComponents)
            {
                context.ProductComponents.Add(new ProductComponent
                {
                    Product = product,
                    Component = context.Components.First(x => x.Id == pc.Key),
                    Count = pc.Value.Item2
                });
            }

            // Сохраняем изменения
            context.SaveChanges();

            // Сбрасываем кэш связанных компонентов, если требуется
            _productComponents = null;
        }

    }
}
