using DiningRoomDataModels.Enums;
using DiningRoomDataModels.Models;

namespace DiningRoomContracts.BindingModels
{
	public class ComponentBindingModel : IComponentModel
	{
		public int Id { get; set; }

        public int UserId { get; set; }
        public string ComponentName { get; set; } = string.Empty;
		public ComponentUnit Unit {  get; set; } = ComponentUnit.Неизвестна;
		public double Cost { get; set; }
	}
}
