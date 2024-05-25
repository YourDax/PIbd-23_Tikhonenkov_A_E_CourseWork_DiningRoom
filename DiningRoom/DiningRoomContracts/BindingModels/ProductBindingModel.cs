using DiningRoomDataModels.Models;

namespace DiningRoomContracts.BindingModels
{
	public class ProductBindingModel : IProductModel
	{
		public int Id { get; set; }

        public string ProductName { get; set; } = string.Empty;

		public double Cost { get; set; }

		public Dictionary<int, (IComponentModel, int)> ProductComponents { get; set; } = new();

	}
}
