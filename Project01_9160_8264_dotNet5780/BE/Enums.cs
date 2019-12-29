using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    /// <summary>
    /// Used to know what 
    /// is the current status of an Order.
    /// </summary>
    public enum OrderStatus
    {
        YetToBeAttendedTo,
        MailWasSent,
        ClosedByTheClient,
        ClosedByExpiration
    }

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
    enum Y_N
    {
        No,
        Yes
    }
}
