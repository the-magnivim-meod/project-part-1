using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Order
    {
        public int HostingUnitKey { get; set; }
        public int GuestRequestKey { get; set; }
        public int OrderKey { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime OrderDate { get; set; }
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
