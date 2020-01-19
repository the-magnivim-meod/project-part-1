using System;
using System.Collections.Generic;
using System.Text;
using BE;
namespace DS
{
    public static class DataSource
    {
        public static List<HostingUnit> HostingUnits = new List<HostingUnit>();
        public static List<GuestRequest> GuestRequests = new List<GuestRequest>();
        public static List<Order> Orders = new List<Order>();
        public static List<BankBranch> BankBranches = new List<BankBranch>()
        {
            new BankBranch()
            {
                BankNumber = 12,
                BankName = "Hapoalim",
                BranchNumber = 11,
                BranchAddress = "poalim@gmail.com",
                BranchCity = "Yerushalaim",
                BankAccountNumber = 1223
            }
        };
    }
}

