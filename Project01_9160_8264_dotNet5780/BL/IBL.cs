using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BE;

namespace BL
{
    public interface IBL
    {
        #region GuestRequest Methods
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
        void UpdateGuestRequest(int guestRequestNumber, GuestRequestStatus status);

        #endregion

        #region hostingUnit Methods
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
        /// sign collection clearance for hosting unit
        /// </summary>
        /// <param name="hotingUnitNumber"></param>
        void SignCollectionClearance(int hotingUnitNumber);
        
        /// <summary>
        /// unsign collection clearance for the  hosting unit
        /// </summary>
        /// <param name="hotingUnitNumber"></param>
        void RemoveCollectionClearance(int hotingUnitNumber);

        /// <summary>
        /// returns a list of all the units that belong to that host
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        List<HostingUnit> GetHostingUnitsOfHost(Host host);
        #endregion

        #region Order Methods
        /// <summary>
        /// add an order to the dataSource
        /// </summary>
        /// <param name="order">the new order</param>
        void AddOrder(Order order);

        /// <summary>
        /// send an invite mail to the guest
        /// </summary>
        /// <param name="orderNumber"></param>
        void SendMail(int orderNumber);

        /// <summary>
        /// change an order status from MailWasSent to DealWasClosed
        /// </summary>
        /// <param name="orderNumber"></param>
        void CloseDeal(int orderNumber);

        /// <summary>
        /// delete an order by its key
        /// </summary>
        /// <param name="orderKey"></param>
        void deleteOrder(int orderKey);
        #endregion

        #region Site Owner Methods
        /// <summary>
        /// returns the total earnings of the site owner
        /// </summary>
        /// <returns></returns>
        int GetTotalEarnings();

        #endregion

        #region get all Methods
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
        /// returns a list of all the hosts in the dataSystem
        /// </summary>
        /// <returns></returns>
        /// 
        //List<Host> GetAllHosts();
        ///// <summary>
        ///// returns a list of all the admins in the dataSystem
        ///// </summary>
        ///// <returns></returns>
        //List<Admin> GetAllAdmins();
        ///// <summary>
        ///// returns a list of all the guests in the dataSystem
        ///// </summary>
        ///// <returns></returns>
        //List<Guest> GetAllGuests();

        public IEnumerable<GuestRequest> GetSuitableRequests(HostingUnit unit);
        #endregion

        #region Miscellaneous Methods

        /// <summary>
        /// returns all the hosting units that are empty at the time requested
        /// </summary>
        /// <param name="date"></param>
        /// <param name="numberDays"></param>
        /// <returns></returns>
        IEnumerable<HostingUnit> GetAllEmptyUnits(DateTime date, int numberDays);

        /// <summary>
        /// returns the amount of days that past from the first date to the second one
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second">default is today</param>
        /// <returns></returns>
        double NumOfDaysPast(DateTime first, DateTime second);

        /// <summary>
        /// returns the number of days past from first until today
        /// </summary>
        /// <param name="first"></param>
        /// <returns></returns>
        double NumOfDaysPast(DateTime first);
        /// <summary>
        /// returns all the orders that the time that past since they were created/an email was sent
        /// is equal or larger to the amount of days given
        /// </summary>
        /// <param name="numDays"></param>
        /// <returns></returns>
        IEnumerable<Order> GetOrders(int numDays);

        /// <summary>
        /// returns all orders that uphold the term given in match
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        IEnumerable<Order> GetAllOrders(Predicate<Order> match);

        /// <summary>
        /// returns the amount of orders the GuestRequest got
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        int NumOrdersGuestRequest(GuestRequest guest);

        /// <summary>
        /// returns the amount of orders that were sent or closed successfuly in this unit 
        /// </summary>
        /// <param name="hostingUnit"></param>
        /// <returns></returns>
        int NumOrdersHostingUnit(HostingUnit hostingUnit);
        #endregion

        #region Grouping Methods
        /// <summary>
        /// group the requests by the area requested
        /// </summary>
        /// <returns>a list of groups</returns>
        IEnumerable<IGrouping<AreaOfTheCountry, GuestRequest>> GroupRequestByArea();

        /// <summary>
        /// group the requests by the number of guests
        /// </summary>
        /// <returns>a list of groups</returns>
        IEnumerable<IGrouping<int, GuestRequest>> GroupRequestByNumberOfGuests();

        /// <summary>
        /// group the Hosts by the amount of units on there possesion
        /// </summary>
        /// <returns>a list of groups</returns>
        IEnumerable<IGrouping<int, Host>> GroupHostByNumberOfUnits();

        /// <summary>
        /// group the hosting units by the area they are in
        /// </summary>
        /// <returns>a list of groups</returns>
        IEnumerable<IGrouping<AreaOfTheCountry, HostingUnit>> GroupUnitsByArea();
        #endregion

        #region user methods
        /// <summary>
        /// get a user from the dataSource by its userName
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetUser(string username);

        /// <summary>
        /// Adds a new guest to the dataSource.
        /// </summary>
        /// <param name="guest">the new guest to be added.</param>
        void AddGuest(User user);

        /// <summary>
        /// Adds a new host to the dataSource.
        /// </summary>
        /// <param name="user">the new host to be added.</param>
        void AddHost(Host host);

        /// <summary>
        /// check if all the fields in the first register page are properly filled
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddHostCanMoveOn(User user);

        /// <summary>
        /// converts the User Details we collected in the first window and puts 
        /// them into a host for us to continue the registration
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Host UserFeildsToHost(User user);

        public Guest GetGuestByUserName(string UserName);

        public Host GetHostByUserName(string UserName);

        List<Host> GetSpecificHosts(Func<Host, bool> conditionFunc);
        #endregion
    }
}
