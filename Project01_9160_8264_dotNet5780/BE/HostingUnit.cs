using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class HostingUnit
    {
        public int HostingUnitKey { get; set; }
        public Host Owner { get; set; }
        public string HostingUnitName { get; set; }
        public bool[,] Diary = new bool[12, 31];
        public HostingUnitType Type { get; set; }
        public AreaOfTheCountry Area { get; set; }        
        public bool HasPool { get; set; }
        public bool HasGarden { get; set; }
        public bool HasNearByGroceryStore { get; set; }
        public bool HasChildrensAttractions { get; set; }
        public override string ToString()
        {
            string output = $"HostingUnitKey {HostingUnitKey}\n";
            output += $"Owner {Owner}\n";
            output += $"HostingUnitName {HostingUnitName}\n";
            output += $"type:{Type}\n";
            output += $"area:{Area}\n";
            output += $"HasPool:{HasPool}, HasGarden:{HasGarden}, HasNearByGroceryStore:{HasNearByGroceryStore}, HasChildrensAttractions:{HasNearByGroceryStore}\n";
            for (int i = 0; i < 12; i++)
            {
                output += $"month:{i}\n";
                for (int j = 0; j < 31; j++)
                {
                    output += $"[day:{j} occupied:{Diary[i,j]}], ";
                }
                output += "\n\n";
            }

            return output;
        }

    }
}
