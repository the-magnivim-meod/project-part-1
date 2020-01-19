﻿using System;
using System.Collections.Generic;
using System.Text;
using BE;
namespace DAL
{
    public interface IDal
    {
        #region guestRequest Methods
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
        ///
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
        #endregion

        #region Order Methods
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
        void deleteOrder(int orderKey);
        #endregion

        #region Get All Methods
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
        #endregion

        #region Get Specific Item By Key Methods
        /// <summary>
        /// get a spedcific order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Order GetOrder(int id);

        /// <summary>
        /// get a specific unit by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        HostingUnit GetHostingUnit(int id);

        /// <summary>
        /// get a specific guestRequest by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GuestRequest GetGuestRequest(int id);
        #endregion

    }
}