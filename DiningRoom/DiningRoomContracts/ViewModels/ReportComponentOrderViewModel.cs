namespace DiningRoomContracts.ViewModels
{
	public class ReportComponentOrderViewModel
	{
		public int ComponentId { get; set; }

		public string ComponentName { get; set; } = string.Empty;

		public double ComponentCost { get; set; }

		public List<(int Count, string ProductName, double ProductPrice, DateTime OrderDate)> Orders { get; set; } = new();
	}
}
