using DiningRoomContracts.BindingModels;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;

namespace DiningRoomContracts.StorageContracts
{
	public interface IComponentStorage
	{
		List<ComponentViewModel> GetFullList();
		
		List<ComponentViewModel> GetFilteredList(ComponentSearchModel Model);
		
		ComponentViewModel? GetElement(ComponentSearchModel Model);
		
		ComponentViewModel? Insert(ComponentBindingModel Model);
		
		ComponentViewModel? Update(ComponentBindingModel Model);
		
		ComponentViewModel? Delete(ComponentBindingModel Model);
        List<ReportComponentOrderViewModel> GetComponentsOrders(List<ComponentSearchModel> Models);

        List<ReportComponentByDateViewModel> GetComponentsByDate(ReportBindingModel ReportModel, UserSearchModel UserModel);
    }
}
