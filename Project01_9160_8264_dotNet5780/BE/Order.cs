using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Order
    {
        int HostingUnitKey;
        int GuestRequestKey;
        int OrderKey;
        OrderStatus Status;
        DateTime CreateDate;
        DateTime OrderDate;
        public override string ToString()
        {
            string output = $"HostingUnitKey {HostingUnitKey} /n";
            output += "_________________________________";
            output += $"GuestRequestKey {GuestRequestKey} /n";
            output += $"OrderKey {OrderKey} /n";
            output += $"status {Status} /n";
            output += $"CreateDate {CreateDate} /n";
            output += $"OrderDate {OrderDate} /n";
            return output;
        }
    }
}
