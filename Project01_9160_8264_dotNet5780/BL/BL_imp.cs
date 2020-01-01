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
        Idal Idal = FactoryDal.GetDal();
        public void AddGuestRequest(GuestRequest guestRequest)
        {
            if (!(guestRequest.EntryDate < guestRequest.ReleaseDate))
            {
                Idal.AddGuestRequest(guestRequest);
            }
        }

        public void AddHostingUnit(HostingUnit hostingUnit)
        {
            Idal.AddHostingUnit(hostingUnit);
        }

        public void AddOrder(Order order)
        {
                Idal.AddOrder(order);
        }

        public void DeleteHostingUnit(int hotingUnitNumber)
        {
            try
            {
                Idal.DeleteHostingUnit(hotingUnitNumber);
            }
            catch (Exception cought)
            {

                throw cought;
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

        public List<IGrouping<AreaOfTheCountry, Host>> GroupHostByNumberOfUnits()
        {
            throw new NotImplementedException();
        }

        public List<IGrouping<AreaOfTheCountry, GuestRequest>> GroupRequestByArea()
        {
            throw new NotImplementedException();
        }

        public List<IGrouping<AreaOfTheCountry, GuestRequest>> GroupRequestByNumberOfGuests()
        {
            throw new NotImplementedException();
        }

        public List<IGrouping<AreaOfTheCountry, HostingUnit>> GroupUnitsByArea()
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

        public void UpdateGuestRequest(int guestRequestNumber, OrderStatus status)
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

        public void UpdateOrder(int orderNumber, OrderStatus status)
        {
            try
            {
                Idal.UpdateOrder(orderNumber, status);
            }
            catch (Exception cought)
            {
                throw cought;
            }
            Console.WriteLine("mail sent\n");
        }

    }
}
