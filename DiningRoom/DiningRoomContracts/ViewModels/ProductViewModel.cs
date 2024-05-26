using DiningRoomDataModels.Models;
using System.ComponentModel;

namespace DiningRoomContracts.ViewModels
{
	public class ProductViewModel : IProductModel
	{
		public int Id { get; set; }
        public int UserId { get; set; }
        public string Login { get; set; } = string.Empty;

        [DisplayName("Название товара")]
		public string ProductName { get; set; } = string.Empty;

		[DisplayName("Стоимость")]
		public double Cost { get; set; }
		public Dictionary<int, (IComponentModel, int)> ProductComponents { get; set; } = new();
	}
}
