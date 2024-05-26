using DiningRoomContracts.ViewModels;

namespace DiningRoomBusinessLogic.OfficePackage.HelperModels
{
    public class PdfInfo
    {
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public List<ReportOrdersViewModel> Orders { get; set; } = new();
    }
}