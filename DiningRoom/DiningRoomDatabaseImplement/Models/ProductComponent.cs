using System.ComponentModel.DataAnnotations;

namespace DiningRoomDatabaseImplement.Models
{
	public class ProductComponent
	{
		public int Id { get; set; }

		[Required]
		public int ProductId { get; set; }

		[Required]
		public int ComponentId { get; set; }

		[Required]
		public int Count { get; set; }

		public virtual Product Product { get; set; } = new();

		public virtual Component Component { get; set; } = new();
	}
}
