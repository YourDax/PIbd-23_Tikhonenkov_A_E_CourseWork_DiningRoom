using DiningRoomDataModels.Models;

namespace DiningRoomContracts.BindingModels
{
	public class ComponentBindingModel : IComponentModel
	{
		public int Id { get; set; }

		public int UserId { get; set; }

		public string ComponentName { get; set; } = string.Empty;
		public string Unit {  get; set; } = string.Empty;
		public double Cost { get; set; }
	}
}
