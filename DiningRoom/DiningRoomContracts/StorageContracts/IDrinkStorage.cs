using DiningRoomContracts.BindingModels;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;

namespace DiningRoomContracts.StorageContracts
{
	public interface IDrinkStorage
	{
		List<DrinkViewModel> GetFullList();

		List<DrinkViewModel> GetFilteredList(DrinkSearchModel Model);

		DrinkViewModel? GetElement(DrinkSearchModel Model);

		DrinkViewModel? Insert(DrinkBindingModel Model);

		DrinkViewModel? Update(DrinkBindingModel Model);

        DrinkViewModel? Delete(DrinkBindingModel Model);
	}
}
