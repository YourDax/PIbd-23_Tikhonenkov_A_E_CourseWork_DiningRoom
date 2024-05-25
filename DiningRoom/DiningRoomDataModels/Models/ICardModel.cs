namespace DiningRoomDataModels.Models
{
	/// <summary>
	/// Товар
	/// </summary>
	public interface ICardModel : IId
	{

		/// <summary>
		/// Название карты
		/// </summary>
		string CardName { get; }
        DateTime DateCardCreate { get; }
    }
}
