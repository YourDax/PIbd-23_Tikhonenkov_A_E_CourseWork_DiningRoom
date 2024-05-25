using DiningRoomDataModels.Models;
using System.ComponentModel;

namespace DiningRoomContracts.ViewModels
{
	public class DrinkViewModel : IDrinkModel
	{
		public int Id { get; set; }
        public string CardName { get; set; } = string.Empty;

        [DisplayName("Название товара")]
		public string DrinkName { get; set; } = string.Empty;

		[DisplayName("Стоимость")]
		public double Cost { get; set; }
		public Dictionary<int, (IComponentModel, int)> DrinkComponents { get; set; } = new();
	}
}
