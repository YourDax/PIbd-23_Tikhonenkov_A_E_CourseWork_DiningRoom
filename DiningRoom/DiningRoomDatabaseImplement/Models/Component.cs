using DiningRoomContracts.BindingModels;
using DiningRoomContracts.ViewModels;
using DiningRoomDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiningRoomDatabaseImplement.Models
{
	public class Component : IComponentModel
	{
		public int Id { get; private set; }

		[Required]
		public int UserId { get; private set; }

		[Required]
		public string ComponentName { get; private set; } = string.Empty;
        public string Unit { get; private set; } = string.Empty;

        [Required]
		public double Cost { get; private set; }

		[ForeignKey("ComponentId")]
		public virtual List<DrinkComponent> DrinkComponents { get; set; } = new();
        [ForeignKey("ComponentId")]
        public virtual List<ProductComponent> ProductComponents { get; set; } = new();

        public static Component Create(ComponentBindingModel Model)
		{
			return new()
			{
				Id = Model.Id,
				UserId = Model.UserId,
				ComponentName = Model.ComponentName,
				Cost = Model.Cost,
                Unit = Model.Unit,
            };
		}

		public void Update(ComponentBindingModel Model)
		{
			ComponentName = Model.ComponentName;
			Cost = Model.Cost;
			Unit = Model.Unit;
		}

		public ComponentViewModel GetViewModel => new()
		{
			Id = Id,
			UserId = UserId,
			ComponentName = ComponentName,
			Cost = Cost,
			Unit = Unit,

		};
	}
}
