using DiningRoomContracts.BindingModels;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomContracts.BusinessLogicContracts
{
	public interface IOrderLogic
	{
		List<OrderViewModel>? ReadList(OrderSearchModel? model);
		OrderViewModel? ReadElement(OrderSearchModel model);
		bool Create(OrderBindingModel model);
		bool Update(OrderBindingModel model);
		bool Delete(OrderBindingModel model);
		bool TakeOrderInWork(OrderBindingModel model);
		bool FinishOrder(OrderBindingModel model);
		bool DeliveryOrder(OrderBindingModel model);
	}
}
