using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BL
{
    class BL_imp : IBL
    {
        static IDal Idal = FactoryDal.GetDal();
        public void AddGuestRequest(GuestRequest guestRequest)
        {
            if (!(guestRequest.EntryDate < guestRequest.ReleaseDate))
            {
                throw new InvalidInputException();
            }
            Idal.AddGuestRequest(guestRequest);
        }

        public void AddHostingUnit(HostingUnit hostingUnit)
        {

            Y_N NO = Y_N.No;
            if (Y_N.No == hostingUnit.Owner.CollectionClearance)
            {
                throw new DAL.LackOfSigningPermission();
            }
            Idal.AddHostingUnit(hostingUnit);
        }

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
            catch (Exception NotExistingKey)
            {

                throw;
            }
        }

        public IEnumerable<BankBranch> GetAllBankBranches()
        {
            throw new NotImplementedException();
        }

        public List<HostingUnit> GetAllEmptyUnits(DateTime date, int numberDays)
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

        public List<Order> GetAllOrders(Predicate<Order> match)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders(int numDays)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGrouping<int, Host>> GroupHostByNumberOfUnits()
        {
            IEnumerable<IGrouping<int, HostingUnit>> hostingUnitsByHosts = from unit in Idal.GetAllHostingUnits()
                                                              group unit by unit.Owner.HostKey;
            IEnumerable<IGrouping<int, Host>> result = from unitsByHost in  hostingUnitsByHosts
                                                       group unitsByHost.





        }

        public IEnumerable<IGrouping<AreaOfTheCountry, GuestRequest>> GroupRequestByArea()
        {
            IEnumerable<IGrouping<AreaOfTheCountry, GuestRequest>> result = from req in Idal.GetAllGuestReuests()
                                                                           group req by req.Area;
            return result;
        }

        public IEnumerable<IGrouping<int, GuestRequest>> GroupRequestByNumberOfGuests()
        {
            IEnumerable<IGrouping<int, GuestRequest>> result = from req in Idal.GetAllGuestReuests()
                                                                           group req by req.Adults + req.Children;
            return result;
        }

        public IEnumerable<IGrouping<AreaOfTheCountry, HostingUnit>> GroupUnitsByArea()
        {
            IEnumerable<IGrouping<AreaOfTheCountry, HostingUnit>> result = from unit in Idal.GetAllHostingUnits()
                                                                           group unit by unit.Area;
            return result;
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



        public void UpdateOrder(int orderNumber, GuestRequestStatus status)
        {
            if (status == GuestRequestStatus.ConnectedToOrder)
            {
                throw new TheDealWasClosed();
            }
            try
            {
                Idal.UpdateGuestRequest(orderNumber, status);
            }
            catch (Exception)
            {
                throw;
            }
            Console.WriteLine("mail sent\n");
        }

    }
}
