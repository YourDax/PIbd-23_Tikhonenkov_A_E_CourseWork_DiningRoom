namespace DiningRoomDataModels.Models
{
	/// <summary>
	/// Товар
	/// </summary>
	public interface IDrinkModel : IId
	{
		/// <summary>
		/// Пользователь, который добавил напиток
		/// </summary>
		int UserId { get; }

		/// <summary>
		/// Название напитка
		/// </summary>
		string DrinkName { get; }

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
