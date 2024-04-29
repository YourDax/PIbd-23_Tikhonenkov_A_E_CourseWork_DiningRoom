namespace DiningRoomDataModels.Models
{
	/// <summary>
	/// Товар
	/// </summary>
	public interface IProductModel : IId
	{
		/// <summary>
		/// Пользователь, который добавил блюдо
		/// </summary>
		int UserId { get; }

		/// <summary>
		/// Название блюда
		/// </summary>
		string ProductName { get; }

		/// <summary>
		/// Стоимость товара
		/// </summary>
		double Cost { get; }

		/// <summary>
		/// Список комплектующих
		/// </summary>
		Dictionary<int, (IComponentModel, int)> ProductComponents { get; }
	}
}
