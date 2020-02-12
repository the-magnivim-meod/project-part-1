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

        private static List<User> users = new List<User>();
        public static List<User> Users { get => users; }

        //---------------------------Hosts List---------------------------//
        private static List<Host> hosts = new List<Host>();
        public static List<Host> Hosts { get => hosts; }

        //---------------------------Guests List---------------------------//
        private static List<Guest> guests = new List<Guest>();
        public static List<Guest> Guests { get => guests; }


    }
}

