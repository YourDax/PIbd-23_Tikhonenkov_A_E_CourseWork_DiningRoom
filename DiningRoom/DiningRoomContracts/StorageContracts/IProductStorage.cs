using DiningRoomContracts.BindingModels;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;

namespace DiningRoomContracts.StorageContracts
{
	public interface IProductStorage
	{
		List<ProductViewModel> GetFullList();

		List<ProductViewModel> GetFilteredList(ProductSearchModel Model);

		ProductViewModel? GetElement(ProductSearchModel Model);

		ProductViewModel? Insert(ProductBindingModel Model);

		ProductViewModel? Update(ProductBindingModel Model);

		ProductViewModel? Delete(ProductBindingModel Model);
	}
}
