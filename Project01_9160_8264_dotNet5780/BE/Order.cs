using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Order
    {
        public int HostingUnitKey;
        public int GuestRequestKey;
        public int OrderKey;
        public OrderStatus Status;
        public DateTime CreateDate;
        public DateTime OrderDate;
        public override string ToString()
        {
            string output = $"HostingUnitKey: {HostingUnitKey} \n";
            output += $"GuestRequestKey: {GuestRequestKey} \n";
            output += $"OrderKey: {OrderKey} \n";
            output += $"status: {Status} \n";
            output += $"CreateDate: {CreateDate} \n";
            output += $"OrderDate: {OrderDate}\n";
            return output;
        }
    }
}
