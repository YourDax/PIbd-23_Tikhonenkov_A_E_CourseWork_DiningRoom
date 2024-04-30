using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.StorageContracts;
using DiningRoomContracts.ViewModels;
using Microsoft.Extensions.Logging;


namespace DiningRoomBusinessLogic.BusinessLogics
{
    public class ProductLogic : IProductLogic
    {
        private readonly ILogger _logger;
        private readonly IProductStorage _ProductStorage;
        public ProductLogic(ILogger<ProductLogic> logger, IProductStorage ProductStorage)
        {
            _logger = logger;
            _ProductStorage = ProductStorage;
        }
        public List<ProductViewModel>? ReadList(ProductSearchModel? model)
        {
            _logger.LogInformation("ReadList. ProductName:{ProductName}. Id:{ Id}", model?.ProductName, model?.Id);
            var list = model == null ? _ProductStorage.GetFullList() : _ProductStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }
        public ProductViewModel? ReadElement(ProductSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. ProductName:{ProductName}. Id:{ Id}", model.ProductName, model.Id);
            var element = _ProductStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }
        public bool Create(ProductBindingModel model)
        {
            CheckModel(model);
            if (_ProductStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }
        public bool Update(ProductBindingModel model)
        {
            CheckModel(model);
            if (_ProductStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }
        public bool Delete(ProductBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_ProductStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }
        private void CheckModel(ProductBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.ProductName))
            {
                throw new ArgumentNullException("Нет названия блюда", nameof(model.ProductName));
            }
            if (model.Cost <= 0)
            {
                throw new ArgumentNullException("Цена блюда должна быть больше 0", nameof(model.Cost));
            }
            _logger.LogInformation("Product. ProductName:{ProductName}. Cost:{ Cost}. Id: { Id}", model.ProductName, model.Cost, model.Id);
            var element = _ProductStorage.GetElement(new ProductSearchModel
            {
                ProductName = model.ProductName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Блюдо с таким названием уже есть");
            }
        }
    }
}
