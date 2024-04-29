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

		public DateTime DateCreate { get; set; } = DateTime.Now;

		public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;
        public Dictionary<int, (IProductModel, int)> ProductOrder { get; set; } = new();
        public Dictionary<int, (IDrinkModel, int)> DrinkOrder { get; set; } = new();

        public double Sum { get; set; }
	}
}
