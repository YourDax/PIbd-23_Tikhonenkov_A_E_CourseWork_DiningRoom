using DiningRoomContracts.ViewModels;

namespace DiningRoomBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public List<ReportComponentOrderViewModel> ProductComponents { get; set; } = new();
    }
}