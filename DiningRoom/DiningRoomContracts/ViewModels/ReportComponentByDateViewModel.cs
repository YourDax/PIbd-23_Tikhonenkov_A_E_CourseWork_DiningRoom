namespace DiningRoomContracts.ViewModels
{
	public class ReportComponentByDateViewModel
	{
		public int ComponentId { get; set; }

		public string ComponentName { get; set; } = string.Empty;

		public double ComponentCost { get; set; }

		public int ProductId { get; set; }

		public string ProductName { get; set; } = string.Empty;

		public double ProductPrice { get; set; }

		public int CardId { get; set; }
		public string CardName { get; set; }

        public DateTime DateCardCreate { get; set; } = DateTime.Now;
    }
}
