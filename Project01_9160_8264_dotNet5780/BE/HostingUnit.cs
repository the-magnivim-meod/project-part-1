using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class HostingUnit
    {
        int HostingUnitKey;
        Host Owner;
        string HostingUnitName;
        bool[,] Diary = new bool[12, 31];
        public override string ToString()
        {
            string output = $"HostingUnitKey {HostingUnitKey} /n";
            output += "_________________________________";
            output += $"Owner {Owner} /n";
            output += $"HostingUnitName {HostingUnitName} /n";

            for (int i = 0; i < 12; i++)
            {
                output += $"month:{i}\n";
                for (int j = 0; j < 31; j++)
                {
                    output += $"day:{j} occupied:{Diary[i,j]}";
                }
                output += "\n";
            }
            return output;
        }

    }
}
