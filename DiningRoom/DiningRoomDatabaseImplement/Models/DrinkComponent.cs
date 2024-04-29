using System.ComponentModel.DataAnnotations;

namespace DiningRoomDatabaseImplement.Models
{
	public class DrinkComponent
	{
		public int Id { get; set; }

		[Required]
		public int DrinkId { get; set; }

		[Required]
		public int ComponentId { get; set; }

		[Required]
		public int Count { get; set; }

		public virtual Drink Drink { get; set; } = new();

		public virtual Component Component { get; set; } = new();
	}
}
