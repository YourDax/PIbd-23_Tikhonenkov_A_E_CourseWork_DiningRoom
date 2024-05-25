namespace DiningRoomDataModels.Models
{
	/// <summary>
	/// Товар
	/// </summary>
	public interface IDrinkModel : IId
	{

		/// <summary>
		/// Название напитка
		/// </summary>
		string DrinkName { get; }

		/// <summary>
		/// Стоимость товара
		/// </summary>
		double Cost { get; }

		/// <summary>
		/// Список продуктов
		/// </summary>
		Dictionary<int, (IComponentModel, int)> DrinkComponents { get; }
	}
}
