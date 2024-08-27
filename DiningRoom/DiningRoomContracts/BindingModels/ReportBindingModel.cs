using DiningRoomContracts.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomContracts.BindingModels
{
	public class ReportBindingModel
	{
		public string FileName { get; set; } = string.Empty;
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		public string? Email { get; set; }
        public List<ComponentSearchModel>? selectedComponents {  get; set; }

    }
}
