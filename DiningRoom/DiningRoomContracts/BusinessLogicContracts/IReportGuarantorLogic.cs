using DiningRoomContracts.BindingModels;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;

namespace DiningRoomContracts.BusinessLogicContracts
{
	public interface IReportGuarantorLogic
	{
		/// <summary>
		/// Получение отчёта для Word или Excel
		/// </summary>
		List<ReportComponentOrderViewModel> GetReportComponentsWithShipments(List<ComponentSearchModel> SelectedComponents);

		/// <summary>
		/// Получение отчёта для отправки на почту
		/// </summary>
		List<ReportComponentByDateViewModel> GetReportComponentsByRequestDate(UserSearchModel CurrentUser, ReportBindingModel Report);
		
		void SaveReportToWordFile(ReportBindingModel Model);

		void SaveReportToExcelFile(ReportBindingModel Model);
	}
}
