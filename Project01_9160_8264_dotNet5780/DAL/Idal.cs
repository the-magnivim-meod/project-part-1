using System;
using System.Collections.Generic;
using System.Text;
using BE;
namespace DAL
{
    internal interface Idal
    {
        void AddGuestRequest(GuestRequest guestRequest);
        void UpdateGuestRequest(int guestRequestNumber, OrderStatus status);

        void AddHostingUnit(HostingUnit hostingUnit);
        void DeleteHostingUnit(int hotingUnitNumber);        
        void UpdateHostingUnit(HostingUnit hostingUnit);

        void AddOrder(Order order);
        void UpdateOrder(int orderNumber, OrderStatus status);


        IEnumerable<HostingUnit> GetAllHostingUnits();

        IEnumerable<GuestRequest> GetAllGuestReuests();


        IEnumerable<Order> GetAllOrders();

        List<BankBranch> GetAllBankBranches();
    }
}
