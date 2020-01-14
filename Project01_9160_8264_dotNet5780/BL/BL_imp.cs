using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BL
{
    class BL_imp : IBL
    {
        static IDal Idal = FactoryDal.GetDal();

        #region GuestRequest Methods
        public void AddGuestRequest(GuestRequest guestRequest)
        {
            if (!(guestRequest.EntryDate < guestRequest.ReleaseDate))
            {
                throw new InvalidInputException();
            }
            Idal.AddGuestRequest(guestRequest);
        }

        public void UpdateGuestRequest(int guestRequestNumber, GuestRequestStatus status)
        {
            try
            {
                Idal.UpdateGuestRequest(guestRequestNumber, status);
            }
            catch (Exception cought)
            {

                throw cought;
            }
        }
        #endregion

        #region hostingUnit Methods
        public void AddHostingUnit(HostingUnit hostingUnit)
        {
            /*if (hostingUnit.Owner.CollectionClearance == Y_N.No)
            {
                throw new DAL.LackOfSigningPermission();
            }*/
            Idal.AddHostingUnit(hostingUnit);
        }

        public void UpdateHostingUnit(HostingUnit hostingUnit)
        {
            try
            {
                Idal.UpdateHostingUnit(hostingUnit);
            }
            catch (Exception cought)
            {

                throw cought;
            }
        }

        public void DeleteHostingUnit(int hotingUnitNumber)
        {
            if (hotingUnitNumber == 0)
            {
                throw new DAL.NotExistingKey();
            }
            try
            {
                Idal.DeleteHostingUnit(hotingUnitNumber);
            }
            catch (Exception notExistingKey)
            {
                throw notExistingKey;
            }
        }
        #endregion

        #region Order Methods
        public void AddOrder(Order order)
        {
            BE.GuestRequest req = Idal.GetGuestRequest(order.GuestRequestKey);
            BE.HostingUnit unit = Idal.GetHostingUnit(order.HostingUnitKey);
           
            for (DateTime currentDate = req.EntryDate; currentDate < req.ReleaseDate; currentDate = currentDate.AddDays(1))
            {
                if (unit.Diary[currentDate.Month - 1, currentDate.Day - 1])
                {
                    throw new TheUnitIsOccupied();
                }              
            }

            Idal.AddOrder(order);

            for (DateTime currentDate = req.EntryDate; currentDate < req.ReleaseDate; currentDate = currentDate.AddDays(1))
            {
                unit.Diary[currentDate.Month - 1, currentDate.Day - 1] = true;
            }
            UpdateHostingUnit(unit);
        }

        public void UpdateOrder(int orderNumber, OrderStatus status)
        {
            Order order = Idal.GetOrder(orderNumber);
            if (order.Status == OrderStatus.DealWasClosed)
            {
                throw new TheDealWasClosed();
            }
            try
            {
                Idal.UpdateOrder(orderNumber, status);
            }
            catch (Exception)
            {
                throw;
            }
            Console.WriteLine("mail sent\n");
        }
        #endregion

        #region Get all Methods
        public IEnumerable<BankBranch> GetAllBankBranches()
        {
            return Idal.GetAllBankBranches();
        }

        public IEnumerable<GuestRequest> GetAllGuestReuests()
        {
            return Idal.GetAllGuestReuests();
        }

        public IEnumerable<HostingUnit> GetAllHostingUnits()
        {
            return Idal.GetAllHostingUnits();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return Idal.GetAllOrders();
        }
        #endregion

        #region Miscellaneous Methods
        public IEnumerable<Order> GetAllOrders(Predicate<Order> match)
        {
            return from order in GetAllOrders()
                   where match(order)
                   select order;
        }

        public IEnumerable<Order> GetOrders(int numDays)
        {
            return from order in GetAllOrders()
                   where CheckForTimeElapsedGetOrder(order,numDays)
                   select order;
           
        } 

        /// <summary>
        /// if the deal was order was yet to be attended to we need to check if the time since the creation date is larger then numDays
        /// else we need to check if numDays is larger then the time that passed since the MailWasSent
        /// </summary>
        /// <param name="order"></param>
        /// <param name="numDays"></param>
        /// <returns></returns>
        private bool CheckForTimeElapsedGetOrder(Order order, int numDays)
        {
            return (order.Status == OrderStatus.YetToBeAttendedTo ? (DateTime.Today - order.CreateDate).TotalDays >= numDays : (DateTime.Today - order.CreateDate).TotalDays >= numDays);
        }

        public IEnumerable<HostingUnit> GetAllEmptyUnits(DateTime date, int numberDays)
        {
            throw new NotImplementedException();
        }
        public int NumOfDaysPast(DateTime first, DateTime second)
        {
            throw new NotImplementedException();
        }

        public int NumOrdersHost(Host host)
        {
            throw new NotImplementedException();
        }

        public int NumOrdersHostingUnit(HostingUnit hostingUnit)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Grouping Methods 
        public IEnumerable<IGrouping<AreaOfTheCountry, GuestRequest>> GroupRequestByArea()
        {
            IEnumerable<IGrouping<AreaOfTheCountry, GuestRequest>> result = from req in Idal.GetAllGuestReuests()
                                                                            group req by req.Area;
            return result;
        }

        public IEnumerable<IGrouping<int, GuestRequest>> GroupRequestByNumberOfGuests()
        {
            IEnumerable<IGrouping<int, GuestRequest>> result = from req in Idal.GetAllGuestReuests()
                                                               let numberOfGuests = req.Adults + req.Children
                                                               group req by numberOfGuests;
            return result;
        }

        public IEnumerable<IGrouping<AreaOfTheCountry, HostingUnit>> GroupUnitsByArea()
        {
            IEnumerable<IGrouping<AreaOfTheCountry, HostingUnit>> result = from unit in Idal.GetAllHostingUnits()
                                                                           group unit by unit.Area;
            return result;
        }

        public IEnumerable<IGrouping<int, Host>> GroupHostByNumberOfUnits()
        {
            //sort hostingUnits by their hosts
            var hostingUnitsByHostId = (from item in Idal.GetAllHostingUnits()
                                        group item by item.Owner);

            //sort the hosts by the amount of hosting units
            return (from item in hostingUnitsByHostId
                    group item.Key by item.Count());
        }
        #endregion
    }
}
