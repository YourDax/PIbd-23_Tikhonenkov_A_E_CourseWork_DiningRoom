using DiningRoomDataModels.Enums;
using DiningRoomDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomContracts.ViewModels
{
	public class OrderViewModel : IOrderModel
	{
		[DisplayName("Номер")]
		public int Id { get; set; }
		
		public int UserId { get; set; }
		[DisplayName("Дата Создания")]
		public DateTime DateCreate { get; set; } = DateTime.Now;
        public Dictionary<int, (IProductModel, int)> ProductOrder { get; set; } = new();
        public Dictionary<int, (IDrinkModel, int)> DrinkOrder { get; set; } = new(); 
		[DisplayName("Статус")]
		public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;

		[DisplayName("Стоимость")]
		public double Sum { get; set; }

	}
}
