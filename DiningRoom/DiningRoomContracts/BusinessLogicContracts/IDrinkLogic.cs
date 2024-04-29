using DiningRoomContracts.BindingModels;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;

namespace DiningRoomContracts.BusinessLogicContracts
{
	public interface IDrinkLogic
	{
		List<DrinkViewModel>? ReadList(DrinkSearchModel? Model);

        DrinkViewModel? ReadElement(DrinkSearchModel Model);

		bool Create(DrinkBindingModel Model);

		bool Update(DrinkBindingModel Model);

		bool Delete(DrinkBindingModel Model);
	}
}
