using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.StorageContracts;
using DiningRoomContracts.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomBusinessLogic.BusinessLogics
{
	public class CardLogic : ICardLogic
	{
		private readonly ILogger _logger;
		private readonly ICardStorage _CardStorage;
		public CardLogic(ILogger<CardLogic> logger, ICardStorage CardStorage)
		{
			_logger = logger;
			_CardStorage = CardStorage;
		}

		public List<CardViewModel>? ReadList(CardSearchModel? model)
		{
			//model.UserId = -1 для swagger, чтобы можно было считать все заявки всех пользователей
			var list = (model == null || model.UserId == -1) ? _CardStorage.GetFullList() : _CardStorage.GetFilteredList(model);
			if (list == null)
			{
				_logger.LogWarning("ReadList Cards return null list");
				return null;
			}
			_logger.LogInformation("ReadList Cards.Count:{Count}", list.Count);
			return list;
		}

		public CardViewModel? ReadElement(CardSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			var element = _CardStorage.GetElement(model);
			if (element == null)
			{
				_logger.LogWarning("ReadElement Card not found");
				return null;
			}
			_logger.LogInformation("ReadElement card found Id:{Id}", element.Id);
			return element;
		}

		public bool Create(CardBindingModel model)
		{
			CheckModel(model);
			if (_CardStorage.Insert(model) == null)
			{
				_logger.LogWarning("Insert operation failed");
				return false;
			}
			return true;
		}

		public bool Update(CardBindingModel model)
		{
			CheckModel(model);
			if (_CardStorage.Update(model) == null)
			{
				_logger.LogWarning("Update operation failed");
				return false;
			}
			return true;
		}

		public bool ConnectCardDrink(CardBindingModel model)
		{
			_logger.LogInformation("Connect Card {rId} with drink {aId}", model.Id, model.DrinkId);
			return _CardStorage.ConnectCardDrink(model);
		}

		public bool Delete(CardBindingModel model)
		{
			CheckModel(model, false);
			_logger.LogInformation("Delete. Id:{Id}", model.Id);
			if (_CardStorage.Delete(model) == null)
			{
				_logger.LogWarning("Delete operation failed");
				return false;
			}
			return true;
		}

		private void CheckModel(CardBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			if (!withParams)
			{
				return;
			}
			if (model.DateCardCreate > DateTime.Now)
			{
				throw new ArgumentException($"Дата создания карты {model.DateCardCreate} не может быть в будущем");
			}
		}
	}
}
