namespace DiningRoomDataModels.Models
{
	/// <summary>
	/// Товар
	/// </summary>
	public interface IProductModel : IId
	{
        /// <summary>
        /// Пользователь, который добавил 
        /// </summary>		
        int UserId { get; }
        /// <summary>
        /// Название блюда
        /// </summary>
        string ProductName { get; }

		/// <summary>
		/// Стоимость блюда
		/// </summary>
		double Cost { get; }

		/// <summary>
		/// Список продуктов
		/// </summary>
		Dictionary<int, (IComponentModel, int)> ProductComponents { get; }
        /// <summary>
        /// Привязка блюда к заказу
        /// </summary>
    }
}
