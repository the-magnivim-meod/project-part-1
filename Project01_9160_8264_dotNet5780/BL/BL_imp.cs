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
            throw new NotImplementedException();
        }

        public void AddHostingUnit(HostingUnit hostingUnit)
        {
            throw new NotImplementedException();
        }

        public void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteHostingUnit(int hotingUnitNumber)
        {
            throw new NotImplementedException();
        }

        public List<BankBranch> GetAllBankBranches()
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
            throw new NotImplementedException();
        }

        public void UpdateHostingUnit(HostingUnit hostingUnit)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(int orderNumber, OrderStatus status)
        {
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
    }
}
