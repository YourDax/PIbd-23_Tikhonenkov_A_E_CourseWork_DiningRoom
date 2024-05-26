using DiningRoomDataModels.Models;

namespace DiningRoomContracts.BindingModels
{
	public class DrinkBindingModel : IDrinkModel
	{
		public int Id { get; set; }
        public int UserId { get; set; }
        public int? CardId { get; set; }
        public string CardName { get; set; } = string.Empty;

        public string DrinkName { get; set; } = string.Empty;

		public double Cost { get; set; }

		public Dictionary<int, (IComponentModel, int)> DrinkComponents { get; set; } = new();

	}
}
