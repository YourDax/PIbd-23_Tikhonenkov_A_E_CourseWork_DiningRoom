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
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
		public string ComponentName { get; private set; } = string.Empty;
        [Required]
        public ComponentUnit Unit { get; private set; } = ComponentUnit.Неизвестна;
        [Required]
        public DateTime DateComponentCreate { get; set; }

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
                DateComponentCreate = Model.DateComponentCreate,
				Cost = Model.Cost,
                Unit = Model.Unit,
                UserId = Model.UserId,
            };
		}
        public static Component Create(ComponentViewModel Model)
        {
            return new Component
            {
                Id = Model.Id,
                ComponentName = Model.ComponentName,
                DateComponentCreate = Model.DateComponentCreate,
                Cost = Model.Cost,
                Unit = Model.Unit,
                UserId = Model.UserId,
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
            DateComponentCreate = DateComponentCreate,
			Cost = Cost,
			Unit = Unit,
            UserId = UserId,

		};
	}
}
