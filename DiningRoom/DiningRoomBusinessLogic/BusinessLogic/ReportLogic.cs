using DiningRoomBusinessLogic.OfficePackage;
using DiningRoomBusinessLogic.OfficePackage.HelperModels;
using DiningRoomBusinessLogic.OfficePackage.Implements;
using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.StorageContracts;
using DiningRoomContracts.ViewModels;
using DocumentFormat.OpenXml.EMMA;

namespace DiningRoomBusinessLogic.BusinessLogic
{
	public class ReportLogic : IReportLogic
	{
        private readonly AbstractSaveToExcel _saveToExcel;

        private readonly AbstractSaveToWord _saveToWord;

        private readonly AbstractSaveToPdf _saveToPdf;

        private readonly IComponentStorage _componentStorage;

		public ReportLogic(IComponentStorage ComponentStorage, AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
		{
			_componentStorage = ComponentStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
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

		public void SaveReportToExcelFile(ReportBindingModel Model, List<ComponentSearchModel> selectedComponents)
		{
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = Model.FileName,
                Title = "Список изделий",
                ProductComponents = GetReportComponentsWithOrders(selectedComponents)
            });
        }
	}
}
