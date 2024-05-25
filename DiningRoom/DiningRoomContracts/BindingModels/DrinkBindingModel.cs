using DiningRoomDataModels.Models;

namespace DiningRoomContracts.BindingModels
{
	public class DrinkBindingModel : IDrinkModel
	{
		public int Id { get; set; }

        public string DrinkName { get; set; } = string.Empty;

		public double Cost { get; set; }

		public Dictionary<int, (IComponentModel, int)> DrinkComponents { get; set; } = new();

	}
}
