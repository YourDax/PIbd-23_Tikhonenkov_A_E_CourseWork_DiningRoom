using DiningRoomContracts.BindingModels;
using DiningRoomContracts.ViewModels;
using DiningRoomDataModels.Enums;
using DiningRoomDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomDatabaseImplement.Models
{
	public class Order : IOrderModel
	{
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public int Count { get; set; }
        [Required]
        public double Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public virtual Product Product { get; set; }
		[Required]
		public int UserId { get; private set; }

		public static Order? Create(OrderBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new Order()
			{
				Id = model.Id,
				ProductId = model.ProductId,
				ProductName = model.ProductName,
				UserId = model.UserId,
				DateCreate = model.DateCreate,
				Status = model.Status,
				Count = model.Count,
				Sum = model.Sum,
			};
		}

		public void Update(OrderBindingModel? model)
		{
			if (model == null)
			{
				return;
			}
			using var context = new DiningRoomDatabase();
			Status = model.Status;
			context.SaveChanges();
		}

		public OrderViewModel GetViewModel 
		{
			get
			{
                using var context = new DiningRoomDatabase();
				return new OrderViewModel
				{
					Id = Id,
					ProductId = ProductId,
					ProductName = context.Products.FirstOrDefault(x => x.Id == ProductId)?.ProductName ?? string.Empty,
					UserId = UserId,
					DateCreate = DateCreate,
					Status = Status,
					Count = Count,
					Sum = Sum
				};
			}
		}
	}
}
