using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    #region stati
    /// <summary>
    /// Used to know what 
    /// is the current status of an Order.
    /// </summary>
    public enum OrderStatus
    {
        YetToBeAttendedTo,
        MailWasSent,
        DealWasClosed,
        ClosedByExpiration,
        ClosedByTheSystem   
    }

    public enum GuestRequestStatus
    {
        YetToBeAttendedTo,
        ConnectedToOrder
    }
    #endregion

    /// <summary>
    /// Used to represent areas
    /// of the country.
    /// </summary>
    public enum AreaOfTheCountry
    {
        North,
        Haifa,
        TelAviv,
        Center,
        Jerusalem,
        South,
        WestBank
    }

    public enum HostingUnitType
    {
        Zimmer,
        Hotel,
        OutdoorCamp
    }

    /// <summary>
    /// How interested is the client in the
    /// extension.
    /// </summary>
    public enum AmountOfIntrenst
    {
        Neccecery,
        Optional,
        NotInterested
    }

    /// <summary>
    /// used to save a boolian in yes/no
    /// instead of true/false
    /// </summary>
    public enum Y_N
    {
        No,
        Yes
    }

    /// <summary>
    /// used to tell what kind of user the user is
    /// </summary>
    public enum UserType
    {
        Guest,
        Host,
        Admin
    }
}
