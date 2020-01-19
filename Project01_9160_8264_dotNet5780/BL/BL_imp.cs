using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BL
{
    /// <summary>
    /// implementation of IBL interface
    /// </summary>
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
            Idal.AddHostingUnit(hostingUnit);
        }

        public void UpdateHostingUnit(HostingUnit hostingUnit)
        {
            HostingUnit old = (from unit in Idal.GetAllHostingUnits()
                               where unit.HostingUnitKey == hostingUnit.HostingUnitKey
                               select unit).First();
            if (hostingUnit.Owner.CollectionClearance == Y_N.No && old.Owner.CollectionClearance == Y_N.Yes)
            {
                foreach (Order order in Idal.GetAllOrders())
                {
                    if (order.HostingUnitKey == hostingUnit.HostingUnitKey)
                    {
                        throw new HostingUnitConnectedToOrderException();
                    }
                }
            }
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

            foreach (Order order in GetAllOrders())
            {
                if (order.HostingUnitKey == hotingUnitNumber)
                {
                    throw new HostingUnitConnectedToOrderException();
                }
            }
            try
            {
                Idal.DeleteHostingUnit(hotingUnitNumber);
            }
            catch (Exception)
            {
                throw new NotExistingKeyException();
            }
        }

        #endregion

        #region Order Methods
        public void AddOrder(Order order)
        {
            BE.GuestRequest req = Idal.GetGuestRequest(order.GuestRequestKey);
            BE.HostingUnit unit = Idal.GetHostingUnit(order.HostingUnitKey);

            //checks if the dates are already occupied
            for (DateTime currentDate = req.EntryDate; currentDate < req.ReleaseDate; currentDate = currentDate.AddDays(1))
            {
                if (unit.Diary[currentDate.Month - 1, currentDate.Day - 1])
                {
                    throw new TheUnitIsOccupiedException();
                }
            }

            //checks if the request is still available
            if (req.Status == GuestRequestStatus.ConnectedToOrder)
            {
                throw new StatusException();
            }
            Idal.AddOrder(order);
        }

        public void UpdateOrder(int orderNumber, OrderStatus status)
        {
            Order order = Idal.GetOrder(orderNumber);
            HostingUnit unit = Idal.GetHostingUnit(order.HostingUnitKey);
            GuestRequest req = Idal.GetGuestRequest(order.GuestRequestKey);
            if (order.Status == OrderStatus.DealWasClosed || order.Status == OrderStatus.ClosedByTheSystem)
            {
                throw new TheOrderIsInavailableException();
            }

            if (status == OrderStatus.MailWasSent)
            {
                //checks if the host signed on collection clearance
                if (unit.Owner.CollectionClearance == Y_N.No)
                {
                    throw new LackOfSigningPermissionException();
                }

                try
                {
                    Idal.UpdateOrder(orderNumber, status);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            else if (status == OrderStatus.DealWasClosed)
            {
                //checks if last status is mailWasSent and that request is still available
                if (order.Status != OrderStatus.MailWasSent || req.Status == GuestRequestStatus.ConnectedToOrder)
                {
                    throw new StatusException();
                }

                //checks if the dates are already occupied
                for (DateTime currentDate = req.EntryDate; currentDate < req.ReleaseDate; currentDate = currentDate.AddDays(1))
                {
                    if (unit.Diary[currentDate.Month - 1, currentDate.Day - 1])
                    {
                        throw new TheUnitIsOccupiedException();
                    }
                }

                try
                {
                    Idal.UpdateOrder(orderNumber, status);
                }
                catch (Exception)
                {
                    throw;
                }
                //fill in the days in the diary
                for (DateTime currentDate = req.EntryDate; currentDate < req.ReleaseDate; currentDate = currentDate.AddDays(1))
                {
                    unit.Diary[currentDate.Month - 1, currentDate.Day - 1] = true;
                }
                Idal.UpdateHostingUnit(unit);
                Idal.UpdateGuestRequest(req.GuestRequestKey, GuestRequestStatus.ConnectedToOrder);
                //change the status of all the orders that were connected to the guestRequests
                foreach (Order order1 in GetAllOrders())
                {
                    if (order1.GuestRequestKey == order.GuestRequestKey && order1.OrderKey != order.OrderKey)
                    {
                        UpdateOrder(order1.OrderKey, OrderStatus.ClosedByTheSystem);
                    }
                }

            }

            {
                try
                {
                    Idal.UpdateOrder(orderNumber, status);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void deleteOrder(int orderKey)
        {
            Idal.deleteOrder(orderKey);
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
                   where CheckForTimeElapsedGetOrder(order, numDays)
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
            return from unit in GetAllHostingUnits()
                   where CheckDatesInUnit(unit, date, numberDays)
                   select unit;

        }
        /// <summary>
        /// checks if the unit is empty in dates from date and up to date+numDays
        /// </summary>
        private bool CheckDatesInUnit(HostingUnit unit, DateTime date, int numDays)
        {
            for (DateTime currentDate = date; currentDate < date.AddDays(numDays); currentDate = currentDate.AddDays(1))
            {
                if (unit.Diary[currentDate.Month - 1, currentDate.Day - 1])
                {
                    return false;
                }
            }
            return true;
        }
        public double NumOfDaysPast(DateTime first, DateTime second)
        {
            return (((second.Date - first.Date)).TotalDays);
        }

        public double NumOfDaysPast(DateTime first)
        {
            return (((DateTime.Today - first.Date)).TotalDays);
        }

        public int NumOrdersGuestRequest(GuestRequest guest)
        {
            return (from order in GetAllOrders()
                    from req in GetAllGuestReuests()
                    where order.GuestRequestKey == req.GuestRequestKey
                    select req).Count();
        }

        public int NumOrdersHostingUnit(HostingUnit hostingUnit)
        {
            return (from order in GetAllOrders()
                    where order.HostingUnitKey == hostingUnit.HostingUnitKey
                    select order).Count();
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
