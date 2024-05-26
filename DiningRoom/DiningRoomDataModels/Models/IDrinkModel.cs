namespace DiningRoomDataModels.Models
{
	/// <summary>
	/// Товар
	/// </summary>
	public interface IDrinkModel : IId
	{
        /// <summary>
        /// Пользователь, который добавил 
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
        public int? CardId { get; set; }

        /// <summary>
        /// Список продуктов
        /// </summary>
        Dictionary<int, (IComponentModel, int)> DrinkComponents { get; }
	}
}
