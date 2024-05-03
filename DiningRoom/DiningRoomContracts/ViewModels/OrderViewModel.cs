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
		public int ProductId { get; set; }
		public int UserId { get; set; }
		[DisplayName("Дата Создания")]
		public DateTime DateCreate { get; set; } = DateTime.Now;
        [DisplayName("Блюдо")]
        public string ProductName { get; set; } = string.Empty;
        [DisplayName("Статус")]
		public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;
        [DisplayName("Количество")]
        public int Count { get; set; }
		[DisplayName("Стоимость")]
		public double Sum { get; set; }

	}
}
