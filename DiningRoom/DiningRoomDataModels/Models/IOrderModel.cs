using DiningRoomDataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomDataModels.Models
{
	public interface IOrderModel : IId
	{
		//ID пользователя, который создал заказ
		int UserId { get; }
		/// <summary>
		/// Дата создания заказа
		/// </summary>
		DateTime DateCreate { get; }

		/// <summary>
		/// Статус заказа
		/// </summary>
		OrderStatus Status { get; }

		/// <summary>
		/// Стоимость  заказа
		/// </summary>
		double Sum { get; }
        Dictionary<int, (IProductModel, int)> ProductOrder { get; }
        Dictionary<int, (IDrinkModel, int)> DrinkOrder { get; }
    }
}
