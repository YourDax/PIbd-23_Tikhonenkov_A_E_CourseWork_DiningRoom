using DiningRoomContracts.BindingModels;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;

namespace DiningRoomContracts.BusinessLogicContracts
{
	public interface IProductLogic
	{
		List<ProductViewModel>? ReadList(ProductSearchModel? Model);

		ProductViewModel? ReadElement(ProductSearchModel Model);

		bool Create(ProductBindingModel Model);

		bool Update(ProductBindingModel Model);

		bool Delete(ProductBindingModel Model);
	}
}
