namespace DiningRoomDataModels.Models
{
	/// <summary>
	/// Комплектующая
	/// </summary>
	public interface IComponentModel : IId
	{
		/// <summary>
		/// Пользователь, который добавил продукт
		/// </summary>
		int UserId { get; }

		/// <summary>
		/// Название продукта
		/// </summary>
		string ComponentName { get; }
        /// <summary>
        /// Единица измерения
        /// </summary>
        string Unit {  get; }

		/// <summary>
		/// Цена продукта
		/// </summary>
		double Cost { get; }

	}
}
