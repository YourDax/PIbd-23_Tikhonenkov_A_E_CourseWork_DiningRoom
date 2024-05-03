using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.StorageContracts;
using DiningRoomContracts.ViewModels;

namespace DiningRoomBusinessLogic.BusinessLogics
{
	public class ReportGuarantorLogic : IReportGuarantorLogic
	{
		private readonly IComponentStorage _componentStorage;

		public ReportGuarantorLogic(IComponentStorage ComponentStorage)
		{
			_componentStorage = ComponentStorage;
		}

		/// <summary>
		/// Получение отчёта для Word или Excel
		/// </summary>
		public List<ReportComponentOrderViewModel> GetReportComponentsWithShipments(List<ComponentSearchModel> SelectedComponents)
		{
			return _componentStorage.GetComponentsOrders(SelectedComponents);
		}

		/// <summary>
		/// Получение отчёта для отправки на почту
		/// </summary>
		public List<ReportComponentByDateViewModel> GetReportComponentsByRequestDate(UserSearchModel CurrentUser, ReportBindingModel Report)
		{
			return _componentStorage.GetComponentsByDate(Report, CurrentUser);
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
