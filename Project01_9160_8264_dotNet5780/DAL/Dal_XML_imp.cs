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

        XElement orderRoot;
        string orderPath = @"orderXML.xml";

        XElement BankAccountLocalPath;
        const string xmlLocalPath = @"atmXML.xml";
        Thread getBankAccounts;

        string adminPath = "AdminXML.xml";

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
            else
            {
                //there is a file and there is nothing to be done
            }
            //order
            if (!File.Exists(orderPath))
            {
                CreateOrderFile();
            }
            else
            {
                orderRoot = XElement.Load(orderPath);
            }

            if (!File.Exists(adminPath))
            {
                CreateAdminFile();
            }
            else
            {
                //there is a file and there is nothing to be done
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
            orderRoot = new XElement("orders");
            orderRoot.Save(orderPath);
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
                    Type = UserType.Admin
                }
            };
            SaveToXML(admins, adminPath);
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
            order.OrderKey = GetOrderKey();
            guestRequestRoot.Add(new XElement("order",
                new XElement("id", order.OrderKey),
                new XElement("foreignKeys", new XElement("guestRequestId", order.GuestRequestKey), new XElement("hostingUnitId", order.HostingUnitKey)),
                new XElement("status", order.Status),
                new XElement("dates", new XElement("creationDate", order.CreateDate), new XElement("orderDate", order.OrderDate))
                ));
            guestRequestRoot.Save(guestRequestPath);
        }

        public void deleteOrder(int orderKey)
        {
            XElement orderElement = (from ord in orderRoot.Elements()
                                     where int.Parse(ord.Element("id").Value) == orderKey
                                     select ord).FirstOrDefault();
            orderElement.Remove();
            orderRoot.Save(orderPath);
        }

        public void UpdateOrder(int orderNumber, OrderStatus status)
        {
            XElement orderElement = (from ord in orderRoot.Elements()
                                     where int.Parse(ord.Element("id").Value) == orderNumber
                                     select ord).FirstOrDefault();
            orderElement.Element("status").Value = status.ToString();
            orderRoot.Save(orderPath);
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
            throw new NotImplementedException();
        }

        public IEnumerable<Admin> getAllAdmins()
        {
            List<Admin> AdminList = LoadFromXML<List<Admin>>(adminPath);
            return from unit in AdminList
                   select unit.Clone();
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

        public bool IsDoneDownlloadingBanks()
        {
            if (getBankAccounts.IsAlive)
            {
                return false;
            }
            return true;
        }
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
    }
}