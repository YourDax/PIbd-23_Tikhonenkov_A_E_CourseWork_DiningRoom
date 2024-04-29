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
		[ForeignKey("ProductId")]
		public int ProductId { get; set; }
		[ForeignKey("UserId")]
		[Required]
		public int UserId { get; private set; }
		public User User { get; set; }
		public virtual Product Product { get; set; }
		[Required]
		public double Sum { get; private set; }
		[Required]
		public int Count { get; private set; }

		[Required]
		public DateTime DateCreate { get; private set; } = DateTime.Now;

		[Required]
		public OrderStatus Status { get; private set; } = OrderStatus.Неизвестен;

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
				UserId = model.UserId,
				DateCreate = model.DateCreate,
				Status = model.Status,
				Count = model.Count,
				Sum = model.Sum,
			};
		}

		public void Update(OrderBindingModel model)
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
