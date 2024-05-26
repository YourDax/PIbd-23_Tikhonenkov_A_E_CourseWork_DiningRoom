namespace DiningRoomDataModels.Models
{
	/// <summary>
	/// Товар
	/// </summary>
	public interface ICardModel : IId
	{
        /// <summary>
        /// Пользователь, который добавил 
        /// </summary>		
        int UserId { get; }
        /// <summary>
        /// Название карты
        /// </summary>
        string CardName { get; }
        DateTime DateCardCreate { get; }
    }
}
