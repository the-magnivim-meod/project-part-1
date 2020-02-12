using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BE
{
    public class HostingUnit
    {
        public int HostingUnitKey { get; set; }
        public Host Owner { get; set; }
        public string HostingUnitName { get; set; }
        [XmlIgnore]
        public bool[,] Diary = new bool[12, 31];

        /// <summary>
        /// used to serialize Diary
        /// </summary>
        public string TempDiary
        {
            get
            {
                if (Diary == null)
                    return null;
                string result = "";
                if (Diary != null) 
                { 
                    int sizeA = Diary.GetLength(0); 
                    int sizeB = Diary.GetLength(1); 
                    result += "" + sizeA + "," + sizeB; 
                    for (int i = 0; i < sizeA; i++) 
                        for (int j = 0; j < sizeB; j++) result += "," + Diary[i, j]; 
                }
                return result;
            }
            set
            {
                if (value != null && value.Length > 0)
                {
                    string[] values = value.Split(',');
                    int sizeA = int.Parse(values[0]);
                    int sizeB = int.Parse(values[1]);
                    Diary = new bool[sizeA, sizeB];
                    int index = 2; for (int i = 0; i < sizeA; i++)
                        for (int j = 0; j < sizeB; j++)
                            Diary[i, j] = bool.Parse(values[index++]);
                }
            }
        }

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
                    output += $"[day:{j} occupied:{Diary[i, j]}], ";
                }
                output += "\n\n";
            }

            return output;
        }

    }
}
