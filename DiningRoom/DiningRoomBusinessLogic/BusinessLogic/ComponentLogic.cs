using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.StorageContracts;
using DiningRoomContracts.ViewModels;
using Microsoft.Extensions.Logging;


namespace DiningRoomBusinessLogic.BusinessLogic
{
    public class ComponentLogic : IComponentLogic
    {
        private readonly ILogger _logger;
        private readonly IComponentStorage _componentStorage;
        public ComponentLogic(ILogger<ComponentLogic> logger, IComponentStorage componentStorage)
        {
            _logger = logger;
            _componentStorage = componentStorage;
        }
        public List<ComponentViewModel>? ReadList(ComponentSearchModel? model)
        {
            _logger.LogInformation("ReadList. ComponentName:{ComponentName}. Id:{ Id}", model?.ComponentName, model?.Id);
        var list = model == null ? _componentStorage.GetFullList() : _componentStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }
        public ComponentViewModel? ReadElement(ComponentSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. ComponentName:{ComponentName}. Id:{ Id}", model.ComponentName, model.Id);
            var element = _componentStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }
        public bool Create(ComponentBindingModel model)
        {
            CheckModel(model);
            if (_componentStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }
        public bool Update(ComponentBindingModel model)
        {
            CheckModel(model);
            if (_componentStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }
        public bool Delete(ComponentBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_componentStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }
        private void CheckModel(ComponentBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.ComponentName))
            {
                throw new ArgumentNullException("Нет названия продукта", nameof(model.ComponentName));
            }
            if (model.Cost <= 0)
            {
                throw new ArgumentNullException("Цена продукта должна быть больше 0", nameof(model.Cost));
            }
            _logger.LogInformation("Component. ComponentName:{ComponentName}. Cost:{ Cost}. Id: { Id}", model.ComponentName, model.Cost, model.Id);
            var element = _componentStorage.GetElement(new ComponentSearchModel
            {
                ComponentName = model.ComponentName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Продукт с таким названием уже есть");
            }
        }
    }
}
