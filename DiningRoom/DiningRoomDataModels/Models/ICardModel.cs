namespace DiningRoomDataModels.Models
{
	/// <summary>
	/// Товар
	/// </summary>
	public interface ICardModel : IId
	{
		/// <summary>
		/// Пользователь, который добавил карту
		/// </summary>
		int UserId { get; }

		/// <summary>
		/// Название напитка
		/// </summary>
		string CardName { get; }

		/// <summary>
		/// Список комплектующих
		/// </summary>
		Dictionary<int, (IDrinkModel, int)> DrinkCard { get; }
	}
}
