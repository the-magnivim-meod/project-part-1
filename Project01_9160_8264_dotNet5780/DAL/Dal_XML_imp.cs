using BE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Threading;
using System.Net;

namespace DAL
{
    /// <summary>
    /// implemintation of xml for data
    /// </summary>
    class Dal_XML_imp : IDal
    {
        XElement guestRequestRoot;
        string guestRequestPath = @"guestRequestXML.xml";

        XElement configRoot;
        string configPath = @"configXML.xml";

        string hostingUnitPath = @"hostingUnitXML.xml";

        string orderPath = @"orderXML.xml";

        //XElement BankAccountLocalPath;
        const string xmlLocalPath = @"atmXML.xml";
        //Thread getBankAccounts;

        string adminPath = "adminXML.xml";
        string guestPath = "guestXML.xml";
        string hostPath = "hostXML.xml";

        public Dal_XML_imp()
        {
            //guestRequest
            if (!File.Exists(guestRequestPath))
            {
                CreateGuestRequestFile();
            }
            else
            {
                guestRequestRoot = XElement.Load(guestRequestPath);
            }
            //config
            if (!File.Exists(configPath))
            {
                CreateConfigFile();
            }
            else
            {
                configRoot = XElement.Load(configPath);
            }
            //hostingUnit
            if (!File.Exists(hostingUnitPath))
            {
                CreateHostingUnitFile();
            }
            //order
            if (!File.Exists(orderPath))
            {
                CreateOrderFile();
            }
            //admin
            if (!File.Exists(adminPath))
            {
                CreateAdminFile();
            }
            //host
            if (!File.Exists(hostPath))
            {
                CreateHostFile();
            }
            //guest
            if (!File.Exists(guestPath))
            {
                CreateGuestFile();
            }
            //getBankAccounts = new Thread(getBanks);
            //getBankAccounts.Start();
        }

        #region create files
        void CreateGuestRequestFile()
        {
            guestRequestRoot = new XElement("guestRequests");
            guestRequestRoot.Save(guestRequestPath);
        }

        void CreateConfigFile()
        {
            configRoot = new XElement("config",
                         new XElement("guestRequestCounter", 1),
                         new XElement("hostingUnitCounter", 1),
                         new XElement("orderCounter", 1),
                         new XElement("hostingUnitCounter", 1),
                         new XElement("totalEarnings", 0));
            configRoot.Save(configPath);
        }

        void CreateHostingUnitFile()
        {
            SaveToXML(new List<HostingUnit>(), hostingUnitPath);
        }

        void CreateOrderFile()
        {
            SaveToXML(new List<Order>(), orderPath);
        }

        void CreateAdminFile()
        {
            List<Admin> admins = new List<Admin>()
            {
                new Admin()
                {
                    UserName = "RackBibi",
                    PrivateName = "Micky",
                    FamilyName = "Zohar",
                    Password = "300000",
                    RegistrationDate = DateTime.Today,
                    Type = UserType.Admin,
                    MailAddress = "MickyZohar@likud.com"
                }
            };
            SaveToXML(admins, adminPath);
        }

        void CreateGuestFile()
        {
            List<Guest> guests = new List<Guest>()
            {
                new Guest()
                {
                    UserName = "Blue",
                    PrivateName = "Yoaz",
                    FamilyName = "Handle",
                    Password = "White",
                    RegistrationDate = DateTime.Today,
                    Type = UserType.Guest,
                    MailAddress = "YoazHandle@CaholLavan.com"
                }
            };
            SaveToXML(guests, guestPath);
        }

        void CreateHostFile()
        {
            List<Host> hosts = new List<Host>()
            {
                new Host()
                {
                    UserName = "RackBibi",
                    PrivateName = "Micky",
                    FamilyName = "Zohar",
                    Password = "300000",
                    RegistrationDate = DateTime.Today,
                    Type = UserType.Host,
                    MailAddress = "",
                    BankAccountNumber = 1,
                    CollectionClearance = Y_N.No,
                    BankBranchDetails = null,
                    finish = false,
                    PhoneNumber = "054-3232-421"
                }
            };
            SaveToXML(hosts,hostPath);
        }
        #endregion

        #region guest Request Methods
        public void AddGuestRequest(GuestRequest guestRequest)
        {
            guestRequest.GuestRequestKey = GetGuestRequestKey();
            guestRequestRoot.Add(new XElement("guestRequest",
                new XElement("id", guestRequest.GuestRequestKey),
                new XElement("name", new XElement("firstName", guestRequest.PrivateName), new XElement("familyName", guestRequest.FamilyName)),
                new XElement("guests", new XElement("adults", guestRequest.Adults), new XElement("children", guestRequest.Children)),
                new XElement("extras", new XElement("pool", guestRequest.Pool), new XElement("garden", guestRequest.Garden), new XElement("groceryStore", guestRequest.CloseByGroceryStore), new XElement("attractions", guestRequest.ChildrensAttractions)),
                new XElement("status", guestRequest.Status),
                new XElement("area", guestRequest.Area),
                new XElement("mail", guestRequest.MailAddress),
                new XElement("dates", new XElement("registrationDate", guestRequest.RegistrationDate), new XElement("entryDate", guestRequest.EntryDate), new XElement("releaseDate", guestRequest.ReleaseDate))
                ));
            guestRequestRoot.Save(guestRequestPath);
        }

        public void UpdateGuestRequest(int guestRequestNumber, GuestRequestStatus status)
        {
            XElement guestRequestElement = (from req in guestRequestRoot.Elements()
                                            where int.Parse(req.Element("id").Value) == guestRequestNumber
                                            select req).FirstOrDefault();
            guestRequestElement.Element("status").Value = status.ToString();
            guestRequestRoot.Save(guestRequestPath);
        }
        #endregion

        #region hosting unit methods
        public void AddHostingUnit(HostingUnit hostingUnit)
        {
            List<HostingUnit> hostingUnitList = LoadFromXML<List<HostingUnit>>(hostingUnitPath);
            hostingUnit.HostingUnitKey = GetHostingUnitKey();
            hostingUnitList.Add(hostingUnit);
            SaveToXML<List<HostingUnit>>(hostingUnitList, hostingUnitPath);

        }

        public void DeleteHostingUnit(int hotingUnitNumber)
        {
            List<HostingUnit> hostingUnitList = LoadFromXML<List<HostingUnit>>(hostingUnitPath);
            int numberDeleted = hostingUnitList.RemoveAll(unit => unit.HostingUnitKey == hotingUnitNumber);
            if (numberDeleted == 0)//which means nothing was deleted
            {
                throw new NotExistingKeyException();
            }
            SaveToXML<List<HostingUnit>>(hostingUnitList, hostingUnitPath);
        }

        public void UpdateHostingUnit(HostingUnit hostingUnit)
        {
            List<HostingUnit> hostingUnitList = LoadFromXML<List<HostingUnit>>(hostingUnitPath);
            int numberDeleted = hostingUnitList.RemoveAll(unit => unit.HostingUnitKey == hostingUnit.HostingUnitKey);
            if (numberDeleted == 0)//which means nothing was deleted
            {
                throw new NotExistingKeyException();
            }
            hostingUnitList.Add(hostingUnit.Clone());
            SaveToXML(hostingUnitList, hostingUnitPath);
        }
        #endregion

        #region order methods
        public void AddOrder(Order order)
        {
            List<Order> orderList = LoadFromXML<List<Order>>(orderPath);
            order.OrderKey = GetOrderKey();
            orderList.Add(order);
            SaveToXML<List<Order>>(orderList, hostingUnitPath);
        }

        public void deleteOrder(int orderKey)
        {
            List<Order> orderList = LoadFromXML<List<Order>>(hostingUnitPath);
            int numberDeleted = orderList.RemoveAll(order => order.OrderKey == orderKey);
            if (numberDeleted == 0)//which means nothing was deleted
            {
                throw new NotExistingKeyException();
            }
            SaveToXML<List<Order>>(orderList, hostingUnitPath);
        }

        public void UpdateOrder(int orderNumber, OrderStatus status)
        {
            List<Order> orderList = LoadFromXML<List<Order>>(hostingUnitPath);
            Order myOrder = orderList.FindAll(order => order.OrderKey == orderNumber).FirstOrDefault();
            if (myOrder == null)//which means the key doesnt exist
            {
                throw new NotExistingKeyException();
            }
            myOrder.Status = status;
            SaveToXML(orderList, hostingUnitPath);
        }
        #endregion

        #region getAll methods
        public IEnumerable<BankBranch> GetAllBankBranches()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GuestRequest> GetAllGuestReuests()
        {
            return from req in guestRequestRoot.Elements()
                   select new GuestRequest()
                   {
                       GuestRequestKey = int.Parse(req.Element("id").Value),
                       Adults = int.Parse(req.Element("guests").Element("adults").Value),
                       Children = int.Parse(req.Element("guests").Element("children").Value),
                       PrivateName = req.Element("name").Element("firstName").Value,
                       FamilyName = req.Element("name").Element("familyName").Value,
                       MailAddress = req.Element("mail").Value,
                       Status = (GuestRequestStatus)Enum.Parse(typeof(GuestRequestStatus), req.Element("status").Value),
                       Area = (AreaOfTheCountry)Enum.Parse(typeof(AreaOfTheCountry), req.Element("area").Value),
                       Pool = (AmountOfIntrenst)Enum.Parse(typeof(AmountOfIntrenst), req.Element("extras").Element("pool").Value),
                       Garden = (AmountOfIntrenst)Enum.Parse(typeof(AmountOfIntrenst), req.Element("extras").Element("garden").Value),
                       ChildrensAttractions = (AmountOfIntrenst)Enum.Parse(typeof(AmountOfIntrenst), req.Element("extras").Element("attractions").Value),
                       CloseByGroceryStore = (AmountOfIntrenst)Enum.Parse(typeof(AmountOfIntrenst), req.Element("extras").Element("groceryStore").Value),
                       RegistrationDate = DateTime.Parse(req.Element("dates").Element("registrationDate").Value),
                       EntryDate = DateTime.Parse(req.Element("dates").Element("entryDate").Value),
                       ReleaseDate = DateTime.Parse(req.Element("dates").Element("releaseDate").Value)
                   }.Clone();
        }

        public IEnumerable<HostingUnit> GetAllHostingUnits()
        {
            List<HostingUnit> hostingUnitList = LoadFromXML<List<HostingUnit>>(hostingUnitPath);
            return from unit in hostingUnitList
                   select unit.Clone();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            List<Order> orderList = LoadFromXML<List<Order>>(orderPath);
            return from ord in orderList
                   select ord.Clone();
        }

        public IEnumerable<Admin> getAllAdmins()
        {
            List<Admin> AdminList = LoadFromXML<List<Admin>>(adminPath);
            return from ad in AdminList
                   select ad.Clone();
        }

        public IEnumerable<Host> GetAllHosts()
        {
            List<Host> HostList = LoadFromXML<List<Host>>(hostPath);
            return from host in HostList
                   select host.Clone();
        }

        public IEnumerable<Guest> GetAllGuests()
        {
            List<Guest> GuestList = LoadFromXML<List<Guest>>(guestPath);
            return from guest in GuestList
                   select guest.Clone();
        }
        #endregion

        #region get item by id 
        public GuestRequest GetGuestRequest(int id)
        {
            throw new NotImplementedException();
        }

        public HostingUnit GetHostingUnit(int id)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public int GetTotalEarnings()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region site owner methods
        public void CollectFee(int dayCount)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region bankAccount

        #endregion

        #region configuration
        int GetGuestRequestKey()
        {
            int old = int.Parse(configRoot.Element("guestRequestCounter").Value);
            configRoot.Element("guestRequestCounter").Value = (old + 1).ToString();
            configRoot.Save(configPath);
            return old;
        }

        int GetHostingUnitKey()
        {
            int old = int.Parse(configRoot.Element("hostingUnitCounter").Value);
            configRoot.Element("hostingUnitCounter").Value = (old + 1).ToString();
            configRoot.Save(configPath);
            return old;
        }

        int GetOrderKey()
        {
            int old = int.Parse(configRoot.Element("orderCounter").Value);
            configRoot.Element("orderCounter").Value = (old + 1).ToString();
            configRoot.Save(configPath);
            return old;
        }
        #endregion

        #region thread
        private static void getBanks()
        {
            bool downloadedSuccefully = false;
            WebClient wc = new WebClient();
            while (!downloadedSuccefully)
            {
                try
                {

                    string xmlServerPath = @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
                    wc.DownloadFile(xmlServerPath, xmlLocalPath);
                    downloadedSuccefully = true;
                }
                catch (Exception)
                {
                    string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
                    wc.DownloadFile(xmlServerPath, xmlLocalPath);
                    downloadedSuccefully = true;
                }
                finally
                {
                    downloadedSuccefully = false;
                    wc.Dispose();
                    Thread.Sleep(1000);
                }
            }
        }

        //public bool IsDoneDownlloadingBanks()
        //{
        //    if (getBankAccounts.IsAlive)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        #endregion

        #region serialize functions
        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source);
            file.Close();
        }
        public static T LoadFromXML<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T result = (T)xmlSerializer.Deserialize(file);
            file.Close(); return result;
        }
        #endregion

        #region User stuff
        public void AddGuest(Guest guest)
        {
            throw new NotImplementedException();
        }

        public void AddHost(Host host)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}