using DiningRoomDataModels.Enums;
using DiningRoomDataModels.Models;
using System.ComponentModel;

namespace DiningRoomContracts.ViewModels
{
	public class ComponentViewModel : IComponentModel
	{
		public int Id { get; set; }


		[DisplayName("Название продукта")]
		public string ComponentName { get; set; } = string.Empty;
        [DisplayName("Единица измерения")]
        public ComponentUnit Unit { get; set; } = ComponentUnit.Неизвестна;
        
        [DisplayName("Стоимость")]
		public double Cost { get; set; }
	}
}
