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
            if (hostingUnit.Owner.CollectionClearance == Y_N.No)
            {
                throw new DAL.LackOfSigningPermission();
            }
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
            int Day1 = req.EntryDate.Day;
            int Month1 = req.EntryDate.Month;
            double NamberOfDays = (req.ReleaseDate - req.EntryDate).TotalDays;
            for (int i = 0; i < NamberOfDays; i++)
            {
                if (unit.Diary[Month1, Day1])
                {
                    throw new TheUnitIsOccupied();
                }
                Day1++;
                if (Day1 == 31)
                {
                    Month1++;
                }


            }
            Idal.AddOrder(order);
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
            throw new NotImplementedException();
        }

        public IEnumerable<GuestRequest> GetAllGuestReuests()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HostingUnit> GetAllHostingUnits()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Miscellaneous Methods
        public List<Order> GetAllOrders(Predicate<Order> match)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders(int numDays)
        {
            throw new NotImplementedException();
        }

        public List<HostingUnit> GetAllEmptyUnits(DateTime date, int numberDays)
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
