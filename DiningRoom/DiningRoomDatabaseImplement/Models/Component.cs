using DiningRoomContracts.BindingModels;
using DiningRoomContracts.ViewModels;
using DiningRoomDataModels.Enums;
using DiningRoomDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiningRoomDatabaseImplement.Models
{
	public class Component : IComponentModel
	{
		public int Id { get; private set; }

		[Required]
		public string ComponentName { get; private set; } = string.Empty;
        [Required]
        public ComponentUnit Unit { get; private set; } = ComponentUnit.Неизвестна;

        [Required]
		public double Cost { get; private set; }

		[ForeignKey("ComponentId")]
		public virtual List<DrinkComponent> DrinkComponents { get; set; } = new();
        [ForeignKey("ComponentId")]
        public virtual List<ProductComponent> ProductComponents { get; set; } = new();

        public static Component? Create(ComponentBindingModel Model)
		{
            if (Model == null)
            {
                return null;
            }
            return new Component()
			{
				Id = Model.Id,
				ComponentName = Model.ComponentName,
				Cost = Model.Cost,
                Unit = Model.Unit,
            };
		}
        public static Component Create(ComponentViewModel Model)
        {
            return new Component
            {
                Id = Model.Id,
                ComponentName = Model.ComponentName,
                Cost = Model.Cost,
                Unit = Model.Unit,
            };
        }
        public void Update(ComponentBindingModel Model)
		{
            if (Model == null)
            {
                return;
            }
            ComponentName = Model.ComponentName;
			Cost = Model.Cost;
			Unit = Model.Unit;
		}

		public ComponentViewModel GetViewModel => new()
		{
			Id = Id,
			ComponentName = ComponentName,
			Cost = Cost,
			Unit = Unit,

		};
	}
}
