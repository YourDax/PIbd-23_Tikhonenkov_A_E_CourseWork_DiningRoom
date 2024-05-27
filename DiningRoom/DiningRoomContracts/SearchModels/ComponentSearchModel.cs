namespace DiningRoomContracts.SearchModels
{
	public class ComponentSearchModel
	{
		public int? Id { get; set; }
        public int? UserId { get; set; }
        public string ComponentName { get; set; }
        public DateTime DateComponentCreate { get; set; }
    }
}
