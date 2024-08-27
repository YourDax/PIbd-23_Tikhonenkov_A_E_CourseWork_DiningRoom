using System.Collections.Generic;
using DiningRoomDataModels.Enums;

namespace DiningRoomUserApp.Models
{
    public class ComponentUnitViewModel
    {
        public List<string> Units { get; set; }

        public ComponentUnitViewModel()
        {
            Units = new List<string>();

            foreach (ComponentUnit unit in Enum.GetValues(typeof(ComponentUnit)))
            {
                Units.Add(unit.ToString());
            }
        }
    }
}
