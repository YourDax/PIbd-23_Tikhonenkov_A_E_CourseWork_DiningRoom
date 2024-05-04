namespace DiningRoomContracts.SearchModels
{
	public class CardSearchModel
	{
		public int? Id { get; set; }

		public int? UserId { get; set; }
		public DateTime? DateCardCreate { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? DrinkId { get; set; }

		public string? Cardname { get; set; }
	}
}
