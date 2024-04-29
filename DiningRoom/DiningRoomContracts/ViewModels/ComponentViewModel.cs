using DiningRoomDataModels.Models;
using System.ComponentModel;

namespace DiningRoomContracts.ViewModels
{
	public class ComponentViewModel : IComponentModel
	{
		public int Id { get; set; }

		public int UserId { get; set; }


		[DisplayName("Название продукта")]
		public string ComponentName { get; set; } = string.Empty;
        [DisplayName("Единица измерения")]
        public string Unit { get; set; } = string.Empty;
        
        [DisplayName("Стоимость")]
		public double Cost { get; set; }
	}
}
