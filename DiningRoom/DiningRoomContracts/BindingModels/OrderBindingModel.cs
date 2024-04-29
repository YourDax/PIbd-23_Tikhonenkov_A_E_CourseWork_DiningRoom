using DiningRoomDataModels.Enums;
using DiningRoomDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomContracts.BindingModels
{
	public class OrderBindingModel : IOrderModel
	{
		public int Id { get; set; }

		public int UserId { get; set; }
        public int ProductId { get; set; }

        public DateTime DateCreate { get; set; } = DateTime.Now;
        public string ProductName { get; set; } = string.Empty;

        public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;
        public int Count { get; set; }
        public double Sum { get; set; }
	}
}
