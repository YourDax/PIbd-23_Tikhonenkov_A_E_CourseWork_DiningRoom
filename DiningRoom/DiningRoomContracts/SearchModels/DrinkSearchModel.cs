namespace DiningRoomContracts.SearchModels
{
	public class DrinkSearchModel
	{
		public int? Id { get; set; }

		public int? UserId { get; set; }
		public int? CardId { get; set; }

        public string? DrinkName { get; set; }
    }
}
