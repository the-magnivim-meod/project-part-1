using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Globalization;

namespace BL
{
    /// <summary>
    /// implementation of IBL interface
    /// </summary>
    class BL_imp : IBL
    {
        static IDal myDal;

        #region Builder and Init
        public BL_imp()
        {
            myDal = FactoryDal.GetDal();
            //init();
        }

        /// <summary>
        /// used to initialize the data source in the mean time in order to check if everything is working
        /// </summary>
        void init()
        {
            //add guests
            AddGuestRequest(
            new GuestRequest()
            {
                PrivateName = "Josh",
                FamilyName = "Wingwear",
                MailAddress = "JWingwear@gmail.com",
                Status = GuestRequestStatus.YetToBeAttendedTo,
                RegistrationDate = DateTime.Today,
                EntryDate = new DateTime(2020, 5, 12),
                ReleaseDate = new DateTime(2020, 5, 16),
                Area = AreaOfTheCountry.Center,
                Type = HostingUnitType.Hotel,
                Adults = 2,
                Children = 3,
                Pool = AmountOfIntrenst.Optional,
                CloseByGroceryStore = AmountOfIntrenst.Neccecery,
                Garden = AmountOfIntrenst.NotInterested,
                ChildrensAttractions = AmountOfIntrenst.NotInterested
            });

            AddGuestRequest(
            new GuestRequest()
            {
                PrivateName = "Ramada",
                FamilyName = "Shtein",
                MailAddress = "ayhhi@gmail.com",
                Status = GuestRequestStatus.YetToBeAttendedTo,
                RegistrationDate = DateTime.Today,
                EntryDate = new DateTime(2019, 12, 22),
                ReleaseDate = new DateTime(2020, 1, 3),
                Area = AreaOfTheCountry.Haifa,
                Type = HostingUnitType.Zimmer,
                Adults = 4,
                Children = 0,
                Pool = AmountOfIntrenst.Neccecery,
                CloseByGroceryStore = AmountOfIntrenst.Optional,
                Garden = AmountOfIntrenst.Neccecery,
                ChildrensAttractions = AmountOfIntrenst.NotInterested
            });

            AddGuestRequest(
            new GuestRequest()
            {
                PrivateName = "yohoshua",
                FamilyName = "barasher",
                MailAddress = "yohushua@gmail.com",
                Status = GuestRequestStatus.YetToBeAttendedTo,
                RegistrationDate = DateTime.Today,
                EntryDate = new DateTime(2020, 2, 28),
                ReleaseDate = new DateTime(2020, 3, 4),
                Area = AreaOfTheCountry.Jerusalem,
                Type = HostingUnitType.Zimmer,
                Adults = 3,
                Children = 8,
                Pool = AmountOfIntrenst.Optional,
                CloseByGroceryStore = AmountOfIntrenst.Neccecery,
                Garden = AmountOfIntrenst.Optional,
                ChildrensAttractions = AmountOfIntrenst.Neccecery
            });
            //end of guestRequestAdditions

            //add hosting units
            AddHostingUnit(
            new HostingUnit()
            {
                HostingUnitName = "HaMalonHamagniv",
                Type = HostingUnitType.Hotel,
                Owner = new Host()
                {
                    BankAccountNumber = 1234,
                    CollectionClearance = Y_N.No,
                    PrivateName = "Amos",
                    FamilyName = "artzi",
                    BankBranchDetails = new BankBranch(),
                    PhoneNumber = "053-472-3327",
                    HostKey = 1,
                    MailAddress = "amosss@yahoo.il"
                }
            });

            AddHostingUnit(
            new HostingUnit()
            {
                HostingUnitName = "ZimmerSha've",
                Type = HostingUnitType.Hotel,
                Owner = new Host()
                {
                    BankAccountNumber = 3839,
                    CollectionClearance = Y_N.No,
                    PrivateName = "Hadas",
                    FamilyName = "Yoff",
                    BankBranchDetails = new BankBranch(),
                    PhoneNumber = "059-780-9363",
                    HostKey = 2,
                    MailAddress = "zimmerShave@Yoff.com"
                }
            });
            //finished adding hosting units
        }
        #endregion

        #region Check Methods
        /// <summary>
        /// check if the order is in an open status a.k.a YetToBeAttendedTo, MailWasSent
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        bool CheckOrderInOpenStatus(Order order)
        {
            if (order.Status == OrderStatus.YetToBeAttendedTo || order.Status == OrderStatus.MailWasSent)
            {
                return true;
            }
            return false;
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

        bool MailAddressIsValid(string address)
        {
            //var a = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
            //return a.IsValid(address);
            if (string.IsNullOrWhiteSpace(address))
                return false;

            try
            {
                // Normalize the domain
                address = Regex.Replace(address, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (System.Text.RegularExpressions.RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(address,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        #endregion

        #region GuestRequest Methods
        public void AddGuestRequest(GuestRequest guestRequest)
        {
            if (!(guestRequest.EntryDate < guestRequest.ReleaseDate))
            {
                throw new DateOrderException();
            }

            else if (!(DateTime.Today <= guestRequest.EntryDate))
            {
                throw new DateComparedToTodayException();
            }

            else if (!(MailAddressIsValid(guestRequest.MailAddress)))
            {
                throw new NotValidEmailAddressException();
            }
            myDal.AddGuestRequest(guestRequest.Clone());
        }

        public void UpdateGuestRequest(int guestRequestNumber, GuestRequestStatus status)
        {
            try
            {
                myDal.UpdateGuestRequest(guestRequestNumber, status);
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
            myDal.AddHostingUnit(hostingUnit.Clone());
        }

        /*public void UpdateHostingUnit(HostingUnit hostingUnit)
        {
            HostingUnit old = (from unit in myDal.GetAllHostingUnits()
                               where unit.HostingUnitKey == hostingUnit.HostingUnitKey
                               select unit).First();
            if (hostingUnit.Owner.CollectionClearance == Y_N.No && old.Owner.CollectionClearance == Y_N.Yes)
            {
                foreach (Order order in myDal.GetAllOrders())
                {
                    if (order.HostingUnitKey == hostingUnit.HostingUnitKey)
                    {
                        throw new HostingUnitConnectedToOrderException();
                    }
                }
            }
            try
            {
                myDal.UpdateHostingUnit(hostingUnit);
            }
            catch (Exception cought)
            {

                throw cought;
            }
        }*/

        public void SignCollectionClearance(int hotingUnitNumber)
        {
            HostingUnit old = (from unit in myDal.GetAllHostingUnits()
                               where unit.HostingUnitKey == hotingUnitNumber
                               select unit).FirstOrDefault();
            if (old == null)
            {
                throw new NotExistingKeyException();
            }

            old.Owner.CollectionClearance = Y_N.Yes;
            try
            {
                myDal.UpdateHostingUnit(old.Clone());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void RemoveCollectionClearance(int hotingUnitNumber)
        {
            HostingUnit old = (from unit in myDal.GetAllHostingUnits()
                               where unit.HostingUnitKey == hotingUnitNumber
                               select unit).FirstOrDefault();
            if (old == null)
            {
                throw new NotExistingKeyException();
            }

            foreach (Order order in myDal.GetAllOrders())
            {
                if (CheckOrderInOpenStatus(order) && order.HostingUnitKey == hotingUnitNumber)
                {
                    throw new HostingUnitConnectedToOrderException();
                }
            }

            old.Owner.CollectionClearance = Y_N.No;
            try
            {
                myDal.UpdateHostingUnit(old.Clone());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteHostingUnit(int hotingUnitNumber)
        {

            foreach (Order order in GetAllOrders())
            {
                //if the hosting unit is connected to an order that is in open stauts
                if (order.HostingUnitKey == hotingUnitNumber && CheckOrderInOpenStatus(order))
                {
                    throw new HostingUnitConnectedToOrderException();
                }
            }
            try
            {
                myDal.DeleteHostingUnit(hotingUnitNumber);
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
            BE.GuestRequest req = myDal.GetGuestRequest(order.GuestRequestKey);
            BE.HostingUnit unit = myDal.GetHostingUnit(order.HostingUnitKey);

            //checks if the dates are already occupied
            for (DateTime currentDate = req.EntryDate; currentDate < req.ReleaseDate; currentDate = currentDate.AddDays(1))
            {
                if (unit.Diary[currentDate.Month - 1, currentDate.Day - 1])
                {
                    throw new TheUnitIsOccupiedException();
                }
            }
            //checks if the request is available
            if (req.Status == GuestRequestStatus.ConnectedToOrder)
            {
                throw new StatusException();
            }
            myDal.AddOrder(order.Clone());
        }

        public void SendMail(int orderNumber)
        {
            Order order = myDal.GetOrder(orderNumber);
            //checks if the order exists
            if (order == null)
            {
                throw new NotExistingKeyException();
            }

            HostingUnit unit = myDal.GetHostingUnit(order.HostingUnitKey);
            GuestRequest req = myDal.GetGuestRequest(order.GuestRequestKey);
            //checks if the deal is the order did not send a mail yet
            if (order.Status != OrderStatus.YetToBeAttendedTo)
            {
                throw new StatusException();
            }

            //if the guestRequest is not available anymore change, close the order
            if (req.Status == GuestRequestStatus.ConnectedToOrder)
            {
                myDal.UpdateOrder(orderNumber, OrderStatus.ClosedByTheSystem);//close the order
                throw new StatusException();
            }

            //checks if the host signed on collection clearance
            if (unit.Owner.CollectionClearance == Y_N.No)
            {
                throw new LackOfSigningPermissionException();
            }

            myDal.UpdateOrder(orderNumber, OrderStatus.MailWasSent);
        }

        public void CloseDeal(int orderNumber)
        {
            Order order = myDal.GetOrder(orderNumber);
            //checks if the order exists
            if (order == null)
            {
                throw new NotExistingKeyException();
            }

            GuestRequest req = myDal.GetGuestRequest(order.GuestRequestKey);
            HostingUnit unit = myDal.GetHostingUnit(order.HostingUnitKey);

            //checks if the deal is the order did not send a mail yet
            if (order.Status != OrderStatus.MailWasSent)
            {
                throw new StatusException();
            }

            //if the guestRequest is not available anymore, change close the order
            if (req.Status == GuestRequestStatus.ConnectedToOrder)
            {
                myDal.UpdateOrder(orderNumber, OrderStatus.ClosedByTheSystem);//close the order
                throw new StatusException();
            }

            //checks if the dates are not occupied
            for (DateTime currentDate = req.EntryDate; currentDate < req.ReleaseDate; currentDate = currentDate.AddDays(1))
            {
                if (unit.Diary[currentDate.Month - 1, currentDate.Day - 1])
                {
                    throw new TheUnitIsOccupiedException();
                }
            }

            //close the deal
            myDal.UpdateOrder(orderNumber, OrderStatus.DealWasClosed);

            //take a fee
            myDal.CollectFee((int)NumOfDaysPast(req.EntryDate, req.ReleaseDate));
            //fill in the days in the diary and update both unit and guestRequest
            for (DateTime currentDate = req.EntryDate; currentDate < req.ReleaseDate; currentDate = currentDate.AddDays(1))
            {
                unit.Diary[currentDate.Month - 1, currentDate.Day - 1] = true;
            }
            myDal.UpdateHostingUnit(unit);
            myDal.UpdateGuestRequest(req.GuestRequestKey, GuestRequestStatus.ConnectedToOrder);

            //close all the other orders that are using the guestRequest
            foreach (Order otherOrder in GetAllOrders())
            {
                if (otherOrder.GuestRequestKey == order.GuestRequestKey && otherOrder.OrderKey != order.OrderKey)
                {
                    myDal.UpdateOrder(otherOrder.OrderKey, OrderStatus.ClosedByTheSystem);
                }
            }

        }

        public void deleteOrder(int orderKey)
        {
            myDal.deleteOrder(orderKey);
        }
        #endregion

        #region Site Owner Methods
        public int GetTotalEarnings()
        {
            return myDal.GetTotalEarnings();
        }
        #endregion

        #region Get all Methods
        public IEnumerable<BankBranch> GetAllBankBranches()
        {
            return myDal.GetAllBankBranches();
        }

        public IEnumerable<GuestRequest> GetAllGuestReuests()
        {
            return myDal.GetAllGuestReuests();
        }

        public IEnumerable<HostingUnit> GetAllHostingUnits()
        {
            return myDal.GetAllHostingUnits();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return myDal.GetAllOrders();
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

        public IEnumerable<HostingUnit> GetAllEmptyUnits(DateTime date, int numberDays)
        {
            return from unit in GetAllHostingUnits()
                   where CheckDatesInUnit(unit, date, numberDays)
                   select unit;

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
            IEnumerable<IGrouping<AreaOfTheCountry, GuestRequest>> result = from req in myDal.GetAllGuestReuests()
                                                                            group req by req.Area;
            return result;
        }

        public IEnumerable<IGrouping<int, GuestRequest>> GroupRequestByNumberOfGuests()
        {
            IEnumerable<IGrouping<int, GuestRequest>> result = from req in myDal.GetAllGuestReuests()
                                                               let numberOfGuests = req.Adults + req.Children
                                                               group req by numberOfGuests;
            return result;
        }

        public IEnumerable<IGrouping<AreaOfTheCountry, HostingUnit>> GroupUnitsByArea()
        {
            IEnumerable<IGrouping<AreaOfTheCountry, HostingUnit>> result = from unit in myDal.GetAllHostingUnits()
                                                                           group unit by unit.Area;
            return result;
        }

        public IEnumerable<IGrouping<int, Host>> GroupHostByNumberOfUnits()
        {
            //sort hostingUnits by their hosts
            var hostingUnitsByHostId = (from item in myDal.GetAllHostingUnits()
                                        group item by item.Owner);

            //sort the hosts by the amount of hosting units
            return (from item in hostingUnitsByHostId
                    group item.Key by item.Count());
        }
        #endregion
    }
}
