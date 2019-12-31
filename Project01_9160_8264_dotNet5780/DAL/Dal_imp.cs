using BE;
using DS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL
{
    class Dal_imp : Idal
    {
        /// <summary>
        /// check if the key already exists
        /// </summary>
        /// <param name="key">the requests key number</param>
        /// <returns>if there is a duplicate</returns>
        bool CheckGuestRequestDuplicates(int key)
        {
            return DataSource.GuestRequests.Any(stud => stud.GuestRequestKey == key);//if the key exists will return true
        }

        /// <summary>
        /// check if the key already exists
        /// </summary>
        /// <param name="key">the requests key number</param>
        /// <returns>if there is a duplicate</returns>
        bool CheckOrderDuplicates(int key)
        {
            return DataSource.Orders.Any(order => order.OrderKey == key);//if the key exists will return true
        }


        /// <summary>
        /// check if the key already exists
        /// </summary>
        /// <param name="key">the requests key number</param>
        /// <returns>if there is a duplicate</returns>
        bool CheckHostingUnitDuplicates(int key)
        {
            return DataSource.Orders.Any(unit => unit.HostingUnitKey == key);//if the key exists will return true
        }

        /// <summary>
        /// adds a new guestRequest to the storage 
        /// </summary>
        /// <param name="guestRequest">the new request to add</param>
        public void AddGuestRequest(GuestRequest guestRequest)
        {
            if(CheckGuestRequestDuplicates(guestRequest.GuestRequestKey))
            {
                throw new Exception("duplicate guestRequest key");
            }
            DataSource.GuestRequests.Add(guestRequest.Clone());
        }

        /// <summary>
        /// adds a new hostingUnit to the storage 
        /// </summary>
        /// <param name="hostingUnit"></param>
        public void AddHostingUnit(HostingUnit hostingUnit)
        {
            if (CheckHostingUnitDuplicates(hostingUnit.HostingUnitKey))
            {
                throw new Exception("duplicate hostingUnit key");
            }
            DataSource.HostingUnits.Add(hostingUnit.Clone());
        }

        /// <summary>
        /// adds a new hostingUnit to the storage 
        /// </summary>
        /// <param name="hostingUnit"></param>
        public void AddOrder(Order order)
        {
            if (CheckHostingUnitDuplicates(order.OrderKey))
            {
                throw new Exception("duplicate Order key");
            }
            DataSource.Orders.Add(order.Clone());
        }

        public void DeleteHostingUnit(int hotingUnitNumber)
        {
            int numberDeleted = DataSource.HostingUnits.RemoveAll(unit => unit.HostingUnitKey == hotingUnitNumber);
            if (numberDeleted == 0)//which means nothing was deleted
            {
                throw new Exception("non existing hostingUnit key");
            }
        }


        public List<BankBranch> GetAllBankBranches()
        {
            return null;
        }

        /// <summary>
        /// get the list of guestRequest
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GuestRequest> GetAllGuestReuests()
        {
            //return cloned version of DataSource.GuestRequests
            return from req in DataSource.GuestRequests
                   select req.Clone();
        }

        /// <summary>
        /// get the list of hostingUnits
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HostingUnit> GetAllHostingUnits()
        {
            //return cloned version of DataSource.HostingUnits
            return from unit in DataSource.HostingUnits
                   select unit.Clone();
        }

        /// <summary>
        /// get the list of orders
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Order> GetAllOrders()
        {
            //return cloned version of DataSource.Orders
            return from order in DataSource.Orders
                   select order.Clone();
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
        /// update the hosting unit by deleting the ld one and adding a new one with the same key
        /// </summary>
        /// <param name="hostingUnitNumber">the hosting unit to update</param>
        public void UpdateHostingUnit(HostingUnit hostingUnit)
        {
            int numberDeleted = DataSource.HostingUnits.RemoveAll(unit => unit.HostingUnitKey == hostingUnit.HostingUnitKey);
            if (numberDeleted == 0)//which means nothing was deleted
            {
                throw new Exception("non existing hostingUnit key");
            }
            DataSource.HostingUnits.Add(hostingUnit.Clone());
        }

        /// <summary>
        /// up
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="status"></param>
        public void UpdateOrder(int orderNumber, OrderStatus status)
        {
            int count = DataSource.Orders.RemoveAll(order => order.OrderKey == orderNumber);
        }
    }
}
