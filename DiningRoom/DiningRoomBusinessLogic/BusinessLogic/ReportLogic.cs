using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.StorageContracts;
using DiningRoomContracts.ViewModels;

namespace DiningRoomBusinessLogic.BusinessLogic
{
	public class ReportLogic : IReportLogic
	{
		private readonly IComponentStorage _componentStorage;

		public ReportLogic(IComponentStorage ComponentStorage)
		{
			_componentStorage = ComponentStorage;
		}

		public List<ReportComponentOrderViewModel> GetReportComponentsWithOrders(List<ComponentSearchModel> SelectedComponents)
		{
			return _componentStorage.GetComponentsOrders(SelectedComponents);
		}

		public List<ReportComponentByDateViewModel> GetReportComponentsByCardDate(ReportBindingModel Report)
		{
			return _componentStorage.GetComponentsByDate(Report);
		}

		public void SaveReportToWordFile(ReportBindingModel Model)
		{
			throw new NotImplementedException();
		}

		public void SaveReportToExcelFile(ReportBindingModel Model)
		{
			throw new NotImplementedException();
		}
	}
}
