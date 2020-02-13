using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private bool CheckOrderInOpenStatus(Order order)
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
                //checks if address matches a valid email address(if the stucture is valid)
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

        public static bool IsValidPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }

        private bool UserNameAlreadyExists(string name)
        {
            if ((from user in GetAllUsers()//if any of the other users have already taken that userName
                 where user.UserName == name
                 select user).Count() > 0)
            {
                return true;
            }
            return false;
        }

        private bool IsVacationAvailable(HostingUnit item, DateTime entryDate, int vacationLength)
        {
            DateTime currentDate = new DateTime(entryDate.Year, entryDate.Month, entryDate.Day);

            for (int i = 0; i < vacationLength; i++)
            {
                if (item.Diary[currentDate.Month - 1, currentDate.Day - 1])
                    return false;
                currentDate = currentDate.AddDays(1);
            }

            return true;
        }

        #endregion

        #region GuestRequest Methods
        public void AddGuestRequest(GuestRequest guestRequest)
        {
            guestRequest.RegistrationDate = DateTime.Today;
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

            else if (guestRequest.Adults < 1)
            {
                throw new AdultAmountException();
            }

            else if (guestRequest.Children < 0)
            {
                throw new ChildrenAmountException();
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
        public List<GuestRequest> GetSpecificGuestRequests(Func<GuestRequest, bool> conditionFunc)
        {
            return (from item in myDal.GetAllGuestReuests()
                    where conditionFunc(item)
                    select item).ToList();
        }
        #endregion

        #region hostingUnit Methods
        public void AddHostingUnit(HostingUnit hostingUnit)
        {
            myDal.AddHostingUnit(hostingUnit.Clone());
        }

        public List<HostingUnit> GetHostingUnitsOfHost(Host host)
        {
            return (from item in GetAllHostingUnits()
                    where item.Owner.PhoneNumber == host.PhoneNumber
                    select item).ToList();
        }

        public void UpdateHostingUnit(HostingUnit hostingUnit)
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
        }

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

        public IEnumerable<GuestRequest> GetSuitableRequests(HostingUnit unit)
        {
            return GetSpecificGuestRequests(item => IsRequestSuitable(unit, item));
        }

        public List<Host> GetSpecificHosts(Func<Host, bool> conditionFunc)
        {
            return (from item in myDal.GetAllHosts()
                    where conditionFunc(item)
                    select item).ToList();
        }

        private bool IsRequestSuitable(HostingUnit hostingUnit, GuestRequest request)
        {
            if (request.Status != GuestRequestStatus.YetToBeAttendedTo)
                return false;
            if (!IsVacationAvailable(hostingUnit, request.EntryDate, Math.Abs(request.EntryDate.Subtract(request.ReleaseDate).Days)))
                return false;
            if (!DoPropertiesFit(hostingUnit, request))
                return false;
            return true;
        }

        private bool DoPropertiesFit(HostingUnit unit, GuestRequest request)
        {
            if (unit.Area != request.Area)
                return false;
            if (request.ChildrensAttractions == AmountOfIntrenst.Neccecery && unit.HasChildrensAttractions == false)
                return false;
            if (request.Garden == AmountOfIntrenst.Neccecery && unit.HasGarden == false)
                return false;
            if (request.CloseByGroceryStore == AmountOfIntrenst.Neccecery && unit.HasNearByGroceryStore == false)
                return false;
            if (request.Pool == AmountOfIntrenst.Neccecery && unit.HasPool == false)
                return false;
            if (request.Type != unit.Type)
                    return false;
            return true;
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

        #region User methods
        private List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            foreach (var guest in myDal.GetAllGuests())
                users.Add(guest);
            foreach (var host in myDal.GetAllHosts())
                users.Add(host);
            foreach (var admin in myDal.GetAllAdmins())
                users.Add(admin);
            return users;
        }

        public User GetUser(string username)
        {
            User user = GetAllUsers().Find(item => item.UserName == username);
            if (user == null)
                throw new NotExistingKeyException();
            return user;
        }

        public void AddGuest(User newUser)
        {
            if (newUser == null)
                throw new ArgumentNullException();
            if (UserNameAlreadyExists(newUser.UserName))
                throw new UserAlreadyExistsException();
            if (!(MailAddressIsValid(newUser.MailAddress)))
                throw new NotValidEmailAddressException();
            Guest guest = new Guest()
            {
                UserName = newUser.UserName,
                Password = newUser.Password,
                PrivateName = newUser.PrivateName,
                FamilyName = newUser.FamilyName,
                Type = newUser.Type,
                MailAddress = newUser.MailAddress,
                RegistrationDate = DateTime.Today
            };

            myDal.AddGuest(guest);
        }


        public bool AddHostCanMoveOn(User newUser)
        {
            if (newUser == null)
                throw new ArgumentNullException();
            if (UserNameAlreadyExists(newUser.UserName))
                throw new UserAlreadyExistsException();
            if (!(MailAddressIsValid(newUser.MailAddress)))
                throw new NotValidEmailAddressException();
            return true;
        }

        public void AddHost(Host host)
        {
            if (host == null)
                throw new ArgumentNullException();
            //if (!(IsValidPhoneNumber(host.PhoneNumber)))
            //    throw new NotValidPhoneNumberException();

            myDal.AddHost(null);
        }

        public Host UserFeildsToHost(User user)
        {
            return new Host()
            {
                UserName = user.UserName,
                Password = user.Password,
                PrivateName = user.PrivateName,
                FamilyName = user.FamilyName,
                Type = user.Type,
                MailAddress = user.MailAddress,
                RegistrationDate = user.RegistrationDate
            };
        }

        public Guest GetGuestByUserName(string UserName)
        {
            Guest g = (from guest in myDal.GetAllGuests()
                       where guest.UserName == UserName
                       select guest).FirstOrDefault();
            return (g == null ? null : g);
        }

        public Host GetHostByUserName(string UserName)
        {
            Host g = (from host in myDal.GetAllHosts()
                      where host.UserName == UserName
                      select host).FirstOrDefault();
            return (g == null ? null : g);
        }
        #endregion

    }
}
