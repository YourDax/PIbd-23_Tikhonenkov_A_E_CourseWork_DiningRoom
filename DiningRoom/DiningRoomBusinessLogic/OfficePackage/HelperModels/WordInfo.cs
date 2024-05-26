using DiningRoomContracts.ViewModels;

namespace DiningRoomBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public List<ProductViewModel> Products { get; set; } = new();
    }
}