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
		/// <summary>
		/// Дата создания заказа
		/// </summary>
		DateTime DateCreate { get; }
        int ProductId { get; }
        /// <summary>
        /// Статус заказа
        /// </summary>
        OrderStatus Status { get; }
        int Count { get; }
        /// <summary>
        /// Стоимость  заказа
        /// </summary>
        double Sum { get; }
        
    }
}
