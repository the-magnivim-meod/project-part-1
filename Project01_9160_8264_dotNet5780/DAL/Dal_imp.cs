//using BE;
//using DS;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Linq;

//namespace DAL
//{
//    class Dal_imp : IDal
//    {
//        #region Check Methods
//        /// <summary>
//        /// check if the key already exists
//        /// </summary>
//        /// <param name="key">the requests key number</param>
//        /// <returns>if there is a duplicate</returns>
//        bool CheckGuestRequestDuplicates(int key)
//        {
//            return DataSource.GuestRequests.Any(stud => stud.GuestRequestKey == key);//if the key exists will return true
//        }

//        /// <summary>
//        /// check if the key already exists
//        /// </summary>
//        /// <param name="key">the requests key number</param>
//        /// <returns>if there is a duplicate</returns>
//        bool CheckOrderDuplicates(int key)
//        {
//            return DataSource.Orders.Any(order => order.OrderKey == key);//if the key exists will return true
//        }


//        /// <summary>
//        /// check if the key already exists
//        /// </summary>
//        /// <param name="key">the requests key number</param>
//        /// <returns>if there is a duplicate</returns>
//        bool CheckHostingUnitDuplicates(int key)
//        {
//            return DataSource.Orders.Any(unit => unit.HostingUnitKey == key);//if the key exists will return true
//        }
//        #endregion

//        #region guestRequest Methods
//        /// <summary>
//        /// adds a new guestRequest to the storage 
//        /// </summary>
//        /// <param name="guestRequest">the new request to add</param>
//        public void AddGuestRequest(GuestRequest guestRequest)
//        {
//            guestRequest.GuestRequestKey = Configuration.GuestRequestCounter;
//            DataSource.GuestRequests.Add(guestRequest.Clone());
//        }

//        /// <summary>
//        /// update the status of a guest request
//        /// </summary>
//        /// <param name="guestRequestNumber">the request to update</param>
//        /// <param name="status">the new status</param>
//        public void UpdateGuestRequest(int guestRequestNumber, GuestRequestStatus status)
//        {
//            GuestRequest oldGuestRequest = DataSource.GuestRequests.Find(req => req.GuestRequestKey == guestRequestNumber);
//            if (oldGuestRequest == null)
//            {
//                throw new NotExistingKeyException();
//            }
//            oldGuestRequest.Status = status;
//        }

//        List<Guest> IDal.GetAllGuests()
//        {
//            return DataSource.Guests;
//        }

//        void IDal.AddGuest(Guest guest)
//        {
//            DataSource.Guests.Add(guest);
//        }

//        #endregion

//        #region hostingUnit Methods
//        /// <summary>
//        /// adds a new hostingUnit to the storage 
//        /// </summary>
//        /// <param name="hostingUnit"></param>
//        public void AddHostingUnit(HostingUnit hostingUnit)
//        {
//            hostingUnit.HostingUnitKey = Configuration.HostingUnitCounter;
//            DataSource.HostingUnits.Add(hostingUnit.Clone());
//        }

//        /// <summary>
//        /// update the hosting unit by deleting the old one and adding a new one with the same key
//        /// </summary>
//        /// <param name="hostingUnitNumber">the hosting unit to update</param>
//        public void UpdateHostingUnit(HostingUnit hostingUnit)
//        {
//            int numberDeleted = DataSource.HostingUnits.RemoveAll(unit => unit.HostingUnitKey == hostingUnit.HostingUnitKey);
//            if (numberDeleted == 0)//which means nothing was deleted
//            {
//                throw new NotExistingKeyException();
//            }
//            DataSource.HostingUnits.Add(hostingUnit.Clone());
//        }

//        public void DeleteHostingUnit(int hotingUnitNumber)
//        {
//            int numberDeleted = DataSource.HostingUnits.RemoveAll(unit => unit.HostingUnitKey == hotingUnitNumber);
//            if (numberDeleted == 0)//which means nothing was deleted
//            {
//                throw new NotExistingKeyException();
//            }
//        }


//        public List<Host> GetAllHosts()
//        {
//            return DataSource.Hosts;
//        }

//        public void AddHost(Host host)
//        {
//            if (KeyInvalid(host.HostKey) || HostExists(host.HostKey))
//                host.HostKey = Configuration.hostCounter++;

//            DataSource.Hosts.Add(host);
//        }

//        private bool HostExists(int hostKey)
//        {
//            return (from item in GetAllHosts()
//                    where item.HostKey == hostKey
//                    select item).ToList().Count > 0;
//        }

//        private bool KeyInvalid(int hostKey)
//        {
//            return hostKey < 1;
//        }

//        #endregion

//        #region order Methods
//        /// <summary>
//        /// adds a new order to the storage 
//        /// </summary>
//        /// <param name="order"></param>
//        public void AddOrder(Order order)
//        {
//            order.OrderKey = Configuration.OrderCounter;
//            DataSource.Orders.Add(order.Clone());
//        }

//        public void UpdateOrder(int orderNumber, OrderStatus status)
//        {
//            Order old_order = DataSource.Orders.Find(order => order.OrderKey == orderNumber);
//            if (old_order == null)
//            {
//                throw new NotExistingKeyException();
//            }
//            old_order.Status = status;
//        }

//        public void deleteOrder(int orderKey)
//        {
//            DS.DataSource.Orders.RemoveAll(order => order.OrderKey == orderKey);
//        }
//        #endregion

//        #region Site Owner Methods
//        public void CollectFee(int dayCount)
//        {
//            Configuration.CollectFee(dayCount);
//        }

//        public int GetTotalEarnings()
//        {
//            return Configuration.TotalEarnedBySiteOwner;
//        }
//        #endregion

//        #region Get all Methods
//        public IEnumerable<BankBranch> GetAllBankBranches()
//        {
//            return from branch in DataSource.BankBranches
//                   select branch.Clone();
//        }

//        /// <summary>
//        /// get the list of guestRequest
//        /// </summary>
//        /// <returns></returns>
//        public IEnumerable<GuestRequest> GetAllGuestReuests()
//        {
//            //return cloned version of DataSource.GuestRequests
//            return from req in DataSource.GuestRequests
//                   select req.Clone();
//        }

//        /// <summary>
//        /// get the list of hostingUnits
//        /// </summary>
//        /// <returns></returns>
//        public IEnumerable<HostingUnit> GetAllHostingUnits()
//        {
//            //return cloned version of DataSource.HostingUnits
//            return from unit in DataSource.HostingUnits
//                   select unit.Clone();
//        }

//        /// <summary>
//        /// get the list of orders
//        /// </summary>
//        /// <returns></returns>
//        public IEnumerable<Order> GetAllOrders()
//        {
//            //return cloned version of DataSource.Orders
//            return from order in DataSource.Orders
//                   select order.Clone();
//        }
//        #endregion

//        #region Get specific item by ID 
//        /// <summary>
//        /// get the order by its guestRequest key
//        /// </summary>
//        /// <param name="key">guestRequest key</param>
//        public Order GetOrderByGuestRequestKey(int key)
//        {
//            return DataSource.Orders.FirstOrDefault(ord => ord.GuestRequestKey == key).Clone();
//        }


//        public GuestRequest GetGuestRequest(int id)
//        {
//            return DataSource.GuestRequests.FirstOrDefault(req => req.GuestRequestKey == id).Clone();
//        }

//        public HostingUnit GetHostingUnit(int id)
//        {
//            return DataSource.HostingUnits.FirstOrDefault(uni => uni.HostingUnitKey == id).Clone();
//        }

//        public Order GetOrder(int id)
//        {
//            return DataSource.Orders.FirstOrDefault(ord => ord.OrderKey == id).Clone();
//        }
//        #endregion
//    }
//}
