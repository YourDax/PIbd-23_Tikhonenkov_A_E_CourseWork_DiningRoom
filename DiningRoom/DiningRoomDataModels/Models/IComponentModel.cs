using DiningRoomDataModels.Enums;

namespace DiningRoomDataModels.Models
{
	/// <summary>
	/// Продукт
	/// </summary>
	public interface IComponentModel : IId
	{
		/// <summary>
		/// Название продукта
		/// </summary>
		string ComponentName { get; }
        /// <summary>
        /// Единица измерения
        /// </summary>
        ComponentUnit Unit {  get; }

		/// <summary>
		/// Цена продукта
		/// </summary>
		double Cost { get; }

	}
}
