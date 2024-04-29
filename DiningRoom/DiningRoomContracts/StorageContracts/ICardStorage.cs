using DiningRoomContracts.BindingModels;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;

namespace DiningRoomContracts.StorageContracts
{
	public interface ICardStorage
	{
		List<CardViewModel> GetFullList();

		List<CardViewModel> GetFilteredList(CardSearchModel Model);

        CardViewModel? GetElement(CardSearchModel Model);

        CardViewModel? Insert(CardBindingModel Model);

        CardViewModel? Update(CardBindingModel Model);

        CardViewModel? Delete(CardBindingModel Model);
	}
}
