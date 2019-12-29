using System;
using System.Collections.Generic;
using System.Text;
using BE;
namespace DAL
{
    interface Idal
    {
        void AddGuestRequest(GuestRequest guestRequest);
        void UpdateGuestRequest(int guestRequestNumber, OrderStatus status);

        void AddHostingUnit(HostingUnit hostingUnit);
        void DeleteHostingUnit(int hotingUnitNumber);
        void UpdateHostingUnit(int hostingUnitNumber);

        void AddOrder(Order order);
        void UpdateOrder(int orderNumber);


        List<HostingUnit> GetAllHostingUnits();

        List<GuestRequest> GetAllGuestReuests();


        List<Order> GetAllOrders();

        List<BankBranch> GetAllBankBranches();
    }
}
