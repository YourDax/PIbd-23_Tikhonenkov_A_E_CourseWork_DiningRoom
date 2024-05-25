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

		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		public string? ProductName { get; set; }

		public OrderStatus? Status { get; set; }

        public double? Sum { get; set; }
	}
}
