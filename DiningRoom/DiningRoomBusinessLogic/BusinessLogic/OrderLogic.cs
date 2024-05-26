using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.StorageContracts;
using DiningRoomContracts.ViewModels;
using DiningRoomDataModels.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomBusinessLogic.BusinessLogic
{
	public class OrderLogic : IOrderLogic
	{
		private readonly ILogger _logger;
		//Хранение всех заказов
		private readonly IOrderStorage _orderStorage;

		public OrderLogic(ILogger<OrderLogic> logger, IOrderStorage orderStorage)
		{
			_logger = logger;
			_orderStorage = orderStorage;
		}

		public List<OrderViewModel>? ReadList(OrderSearchModel? model)
		{
			
			var list = (model == null) ? _orderStorage.GetFullList() : _orderStorage.GetFilteredList(model);
			if (list == null)
			{
				_logger.LogWarning("ReadList return null list");
				return null;
			}
			_logger.LogInformation("ReadList. Count:{Count}", list.Count);
			return list;
		}


		public OrderViewModel? ReadElement(OrderSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			var element = _orderStorage.GetElement(model);
			if (element == null)
			{
				_logger.LogWarning("ReadElement order not found");
				return null;
			}
			_logger.LogInformation("ReadElement order found. Id:{Id}", element.Id);
			return element;
		}

		private void CheckModel(OrderBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			if (model.DateCreate > DateTime.Now)
			{
				throw new ArgumentException($"Дата создания заказа {model.DateCreate} не может быть в будущем");
			}
		}

		public bool Create(OrderBindingModel model)
		{
			CheckModel(model);
			model.Status = OrderStatus.Принят;
			if (_orderStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");
				return false;
			}
			return true;

		}

		
		public bool Update(OrderBindingModel model)
		{
			CheckModel(model, false);
			var order = _orderStorage.GetElement(new OrderSearchModel { Id = model.Id });
			if (order == null)
			{
				throw new ArgumentNullException(nameof(order));
			}
			if (_orderStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}
			return true;
		}

		public bool Delete(OrderBindingModel model)
		{
			CheckModel(model, false);
			_logger.LogInformation("Delete. Id:{Id}", model.Id);
			if (_orderStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete order operation failed");
				return false;
			}
			return true;
		}

        public bool ChangeStatus(OrderBindingModel model, OrderStatus newStatus)
        {
            var vmodel = _orderStorage.GetElement(new() { Id = model.Id });

            if (vmodel == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if ((int)vmodel.Status + 1 != (int)newStatus)
            {
                throw new InvalidOperationException($"Попытка перевести заказ не в следующий статус: " +
                    $"Текущий статус: {vmodel.Status} \n" +
                    $"Планируемый статус: {newStatus} \n" +
                    $"Доступный статус: {(OrderStatus)((int)vmodel.Status + 1)}");
            }

            model.Status = newStatus;
            model.DateCreate = vmodel.DateCreate;

            model.ProductId = vmodel.ProductId;
            model.Sum = vmodel.Sum;
            model.Count = vmodel.Count;

            var result = _orderStorage.Update(model);

            if (result == null)
            {
                _logger.LogWarning("Update operation failed");

                return false;
            }
            return true;
        }

		//Перевод заказа в состояние выполнения
		public bool TakeOrderInWork(OrderBindingModel model)
		{
			return ChangeStatus(model, OrderStatus.Выполняется);
		}

		//Перевод заказа в состояние готовности
		public bool FinishOrder(OrderBindingModel model)
		{
			return ChangeStatus(model, OrderStatus.Готов);
		}
		//Перевод заказа в состояние выдачи (окончательное завершение)
		public bool DeliveryOrder(OrderBindingModel model)
		{
			return ChangeStatus(model, OrderStatus.Выдан);
		}
	}
}
