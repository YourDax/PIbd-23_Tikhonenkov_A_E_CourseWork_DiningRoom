using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.StorageContracts;
using DiningRoomContracts.ViewModels;
using Microsoft.Extensions.Logging;


namespace DiningRoomBusinessLogic.BusinessLogics
{
    public class DrinkLogic : IDrinkLogic
    {
        private readonly ILogger _logger;
        private readonly IDrinkStorage _DrinkStorage;
        public DrinkLogic(ILogger<DrinkLogic> logger, IDrinkStorage DrinkStorage)
        {
            _logger = logger;
            _DrinkStorage = DrinkStorage;
        }
        public List<DrinkViewModel>? ReadList(DrinkSearchModel? model)
        {
            _logger.LogInformation("ReadList. DrinkName:{DrinkName}. Id:{ Id}", model?.DrinkName, model?.Id);
            var list = model == null ? _DrinkStorage.GetFullList() : _DrinkStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }
        public DrinkViewModel? ReadElement(DrinkSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. DrinkName:{DrinkName}. Id:{ Id}", model.DrinkName, model.Id);
            var element = _DrinkStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }
        public bool Create(DrinkBindingModel model)
        {
            CheckModel(model);
            if (_DrinkStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }
        public bool Update(DrinkBindingModel model)
        {
            CheckModel(model);
            if (_DrinkStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }
        public bool Delete(DrinkBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_DrinkStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }
        private void CheckModel(DrinkBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.DrinkName))
            {
                throw new ArgumentNullException("Нет названия напитка", nameof(model.DrinkName));
            }
            if (model.Cost <= 0)
            {
                throw new ArgumentNullException("Цена напитка должна быть больше 0", nameof(model.Cost));
            }
            _logger.LogInformation("Drink. DrinkName:{DrinkName}. Cost:{ Cost}. Id: { Id}", model.DrinkName, model.Cost, model.Id);
            var element = _DrinkStorage.GetElement(new DrinkSearchModel
            {
                DrinkName = model.DrinkName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Напиток с таким названием уже есть");
            }
        }
        public bool ConnectCardDrink(DrinkBindingModel model)
        {
            _logger.LogInformation("Connect Card {rId} with drink {aId}", model.Id, model.CardId);
            return _DrinkStorage.ConnectCardDrink(model);
        }
    }
}
