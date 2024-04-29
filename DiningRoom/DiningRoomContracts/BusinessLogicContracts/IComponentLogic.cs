using DiningRoomContracts.BindingModels;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;

namespace DiningRoomContracts.BusinessLogicContracts
{
	public interface IComponentLogic
	{
		List<ComponentViewModel>? ReadList(ComponentSearchModel? Model);
		
		ComponentViewModel? ReadElement(ComponentSearchModel Model);
		
		bool Create(ComponentBindingModel Model);
		
		bool Update(ComponentBindingModel Model);
		
		bool Delete(ComponentBindingModel Model);
	}
}
