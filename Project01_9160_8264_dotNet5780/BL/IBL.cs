using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BE;

namespace BL
{
    interface IBL
    {
        /// <summary>
        /// add a guestRequest to the DataSource
        /// </summary>
        /// <param name="guestRequest">the request to add</param>
        void AddGuestRequest(GuestRequest guestRequest);

        /// <summary>
        /// update the guestRequest's status
        /// </summary>
        /// <param name="guestRequestNumber">the request to update</param>
        /// <param name="status">the new stauts</param>
        void UpdateGuestRequest(int guestRequestNumber, OrderStatus status);

        /// <summary>
        /// add a hostingUnit to the DataSource
        /// </summary>
        /// <param name="hostingUnit">the unit to add</param>
        void AddHostingUnit(HostingUnit hostingUnit);
        /// <summary>
        /// delete a hostingUnit from the Data source 
        /// </summary>
        /// <param name="hotingUnitNumber">the unit to delete's number</param>
        void DeleteHostingUnit(int hotingUnitNumber);
        /// <summary>
        /// update a hosting unit
        /// </summary>
        /// <param name="hostingUnit">the hosting unit to update</param>
        void UpdateHostingUnit(HostingUnit hostingUnit);

        /// <summary>
        /// add an order to the dataSource
        /// </summary>
        /// <param name="order">the new order</param>
        void AddOrder(Order order);
        /// <summary>
        /// update an Order's status
        /// </summary>
        /// <param name="orderNumber">the order to update</param>
        /// <param name="status">the new status</param>
        void UpdateOrder(int orderNumber, OrderStatus status);

        /// <summary>
        /// return all of the hosting units in the dataSource
        /// </summary>
        /// <returns></returns>
        IEnumerable<HostingUnit> GetAllHostingUnits();
        /// <summary>
        /// return all of the guestRequests in the dataSource
        /// </summary>
        /// <returns></returns>
        IEnumerable<GuestRequest> GetAllGuestReuests();
        /// <summary>
        /// return all of the orders in the dataSource
        /// </summary>
        /// <returns></returns>
        IEnumerable<Order> GetAllOrders();
        /// <summary>
        /// return all of the bankBranches in the dataSource
        /// </summary>
        /// <returns></returns>
        IEnumerable<BankBranch> GetAllBankBranches();

        /// <summary>
        /// returns all the hosting units that are empty at the time requested
        /// </summary>
        /// <param name="date"></param>
        /// <param name="numberDays"></param>
        /// <returns></returns>
        List<HostingUnit> GetAllEmptyUnits(DateTime date, int numberDays);

        /// <summary>
        /// returns the amount of days that past from the first date to the second one
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second">default is today</param>
        /// <returns></returns>
        int NumOfDaysPast(DateTime first, DateTime second /*=today*/);


        /// <summary>
        /// returns all the orders that the time that past since they were created/an email was sent
        /// is equal or larger to the amount of days given
        /// </summary>
        /// <param name="numDays"></param>
        /// <returns></returns>
        List<Order> GetOrders(int numDays);

        /// <summary>
        /// returns all orders that uphold the term given in match
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        List<Order> GetAllOrders(Predicate<Order> match);

        /// <summary>
        /// returns the amount of orders the host got
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        int NumOrdersHost(Host host);

        /// <summary>
        /// returns the amount of orders that were sent or closed successfuly in this unit 
        /// </summary>
        /// <param name="hostingUnit"></param>
        /// <returns></returns>
        int NumOrdersHostingUnit(HostingUnit hostingUnit);

        /// <summary>
        /// group the requests by the area requested
        /// </summary>
        /// <returns>a list of groups</returns>
        List<IGrouping<AreaOfTheCountry, GuestRequest>> GroupRequestByArea();

        /// <summary>
        /// group the requests by the number of guests
        /// </summary>
        /// <returns>a list of groups</returns>
        List<IGrouping<AreaOfTheCountry, GuestRequest>> GroupRequestByNumberOfGuests();

        /// <summary>
        /// group the Hosts by the amount of units on there possesion
        /// </summary>
        /// <returns>a list of groups</returns>
        List<IGrouping<AreaOfTheCountry, Host>> GroupHostByNumberOfUnits();

        /// <summary>
        /// group the hosting units by the area they are in
        /// </summary>
        /// <returns>a list of groups</returns>
        List<IGrouping<AreaOfTheCountry, HostingUnit>> GroupUnitsByArea();
    }
}
