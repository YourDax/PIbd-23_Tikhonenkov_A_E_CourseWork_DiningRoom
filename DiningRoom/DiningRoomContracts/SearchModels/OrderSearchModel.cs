using DiningRoomDataModels.Enums;
using DiningRoomDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomContracts.SearchModels
{
	public class OrderSearchModel
	{
		public int? Id { get; set; }
		public int? UserId { get; set; }

		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }

		public OrderStatus? Status { get; set; }
        public Dictionary<int, (IProductModel, int)> ProductOrder { get; set; } = new();
        public Dictionary<int, (IDrinkModel, int)> DrinkOrder { get; set; } = new();

        public double? Sum { get; set; }
	}
}
