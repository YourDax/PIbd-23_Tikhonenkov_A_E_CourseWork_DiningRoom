using DiningRoomDataModels.Enums;

namespace DiningRoomContracts.ViewModels
{
    public class ReportOrdersViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public double Sum { get; set; }
        public string Status { get; set; } = string.Empty ;
    }
}