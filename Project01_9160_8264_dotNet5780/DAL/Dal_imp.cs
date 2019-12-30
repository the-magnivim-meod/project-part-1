using BE;
using DS;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    class Dal_imp : Idal
    {
        public void AddGuestRequest(GuestRequest guestRequest)
        {
            if(guestRequest != null)
            {
                DataSource.GuestRequests.Add(guestRequest);
            }
        }

        public void AddHostingUnit(HostingUnit hostingUnit)
        {
            if (hostingUnit != null)
            {
                DataSource.HostingUnits.Add(hostingUnit);
            }
        }

        public void AddOrder(Order order)
        {
            if (order != null)
            {
                DataSource.Orders.Add(order);
            }
        }

        public void DeleteHostingUnit(int hotingUnitNumber)
        {
            foreach (HostingUnit item in DataSource.HostingUnits)
            {
                if(item.HostingUnitKey == hotingUnitNumber)
                {
                    DataSource.HostingUnits.Remove(item);
                }
            }
        }

        public List<BankBranch> GetAllBankBranches()
        {
            return null;
        }

        public List<GuestRequest> GetAllGuestReuests()
        {
            return DataSource.GuestRequests;
        }

        public List<HostingUnit> GetAllHostingUnits()
        {
            return DataSource.HostingUnits;
        }

        public List<Order> GetAllOrders()
        {
            return DataSource.Orders;
        }

        /// <summary>
        /// update the status of a guest request
        /// </summary>
        /// <param name="guestRequestNumber">the request to updaate</param>
        /// <param name="status">the new status</param>
        public void UpdateGuestRequest(int guestRequestNumber, OrderStatus status)
        {
            foreach (GuestRequest item in DataSource.GuestRequests)
            {
                if (item.GuestRequestKey == guestRequestNumber)
                {
                    item.Status = status;
                }
            }
        }

        /// <summary>
        /// update the hosting unit... not sure how
        /// </summary>
        /// <param name="hostingUnitNumber">the hosting unit to update</param>
        public void UpdateHostingUnit(int hostingUnitNumber)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(int orderNumber, OrderStatus status)
        {
            foreach (Order item in DataSource.Orders)
            {
                if (item.OrderKey == orderNumber)
                {
                    item.Status = status;
                }
            }
        }
    }
}
