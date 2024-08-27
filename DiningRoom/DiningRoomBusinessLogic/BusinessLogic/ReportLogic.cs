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

		public List<ReportComponentByDateViewModel> GetReportComponentsByDate(ReportBindingModel Report)
		{
			return _componentStorage.GetComponentsByDate(Report);
		}
        public void SaveComponentsToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список продуктов",
                DateFrom = model.DateFrom!.Value,
                DateTo = model.DateTo!.Value,
                Components = GetReportComponentsByDate(model)
            });
        }

        public void SaveReportToWordFile(ReportBindingModel Model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = Model.FileName,
                Title = "Список заказов",
                ProductComponents = GetReportComponentsWithOrders(Model.selectedComponents)
            });
        }

		public void SaveReportToExcelFile(ReportBindingModel Model)
		{
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = Model.FileName,
                Title = "Список заказов",
                ProductComponents = GetReportComponentsWithOrders(Model.selectedComponents)
            });
        }
	}
}
