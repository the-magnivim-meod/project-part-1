//using BE;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Xml.Linq;
//using System.IO;
//using System.Linq;
//using System.Xml.Serialization;
//using System.Threading;
//using System.Net;

//namespace DAL
//{
//    /// <summary>
//    /// implemintation of xml for data
//    /// </summary>
//    class Dal_XML_imp : IDal
//    {
//        XElement guestRequestRoot;
//        string guestRequestPath = @"guestRequestXML.xml";

//        XElement configRoot;
//        string configPath = @"config.xml";

//        XElement hostingUnitRoot;
//        string hostingUnitPath = @"hostingUnit.xml";

//        XElement orderRoot;
//        string orderPath = @"order.xml";

//        XElement BankAccountLocalPath;
//        const string xmlLocalPath = @"atm.xml";
//        Thread getBankAccounts;

//        public Dal_XML_imp()
//        {
//            //guestRequest
//            if (!File.Exists(guestRequestPath))
//            {
//                CreateGuestRequestFile();
//            }
//            else
//            {
//                guestRequestRoot = XElement.Load(guestRequestPath);
//            }
//            //config
//            if (!File.Exists(configPath))
//            {
//                CreateConfigFile();
//            }
//            else
//            {
//                configRoot = XElement.Load(configPath);
//            }
//            //hostingUnit
//            if (!File.Exists(hostingUnitPath))
//            {
//                CreateHostingUnitFile();
//            }
//            else
//            {
//                hostingUnitRoot = XElement.Load(hostingUnitPath);
//            }
//            //order
//            if (!File.Exists(orderPath))
//            {
//                CreateOrderFile();
//            }
//            else
//            {
//                orderRoot = XElement.Load(orderPath);
//            }

//            getBankAccounts = new Thread(getBanks);
//            getBankAccounts.Start();
//        }

//        #region create files
//        void CreateGuestRequestFile()
//        {
//            guestRequestRoot = new XElement("guestRequests");
//            guestRequestRoot.Save(guestRequestPath);
//        }

//        void CreateConfigFile()
//        {
//            configRoot = new XElement("config",
//                         new XElement("guestRequestCounter", 1),
//                         new XElement("hostingUnitCounter", 1),
//                         new XElement("orderCounter", 1),
//                         new XElement("hostingUnitCounter", 1),
//                         new XElement("totalEarnings", 0));
//            configRoot.Save(configPath);
//        }

//        void CreateHostingUnitFile()
//        {
//            hostingUnitRoot = new XElement("hostingUnits");
//            hostingUnitRoot.Save(hostingUnitPath);
//        }

//        void CreateOrderFile()
//        {
//            orderRoot = new XElement("orders");
//            orderRoot.Save(orderPath);
//        }
//        #endregion

//        #region guest Request Methods
//        public void AddGuestRequest(GuestRequest guestRequest)
//        {
//            guestRequest.GuestRequestKey = GetGuestRequestKey();
//            guestRequestRoot.Add(new XElement("guestRequest",
//                new XElement("id", guestRequest.GuestRequestKey),
//                new XElement("name", new XElement("firstName", guestRequest.PrivateName), new XElement("familyName", guestRequest.FamilyName)),
//                new XElement("guests", new XElement("adults", guestRequest.Adults), new XElement("children", guestRequest.Children)),
//                new XElement("extras", new XElement("pool", guestRequest.Pool), new XElement("garden", guestRequest.Garden), new XElement("groceryStore", guestRequest.CloseByGroceryStore), new XElement("attractions", guestRequest.ChildrensAttractions)),
//                new XElement("status", guestRequest.Status),
//                new XElement("area", guestRequest.Area),
//                new XElement("mail", guestRequest.MailAddress),
//                new XElement("dates", new XElement("registrationDate", guestRequest.RegistrationDate), new XElement("entryDate", guestRequest.EntryDate), new XElement("releaseDate", guestRequest.ReleaseDate))
//                ));
//            guestRequestRoot.Save(guestRequestPath);
//        }

//        public void UpdateGuestRequest(int guestRequestNumber, GuestRequestStatus status)
//        {
//            XElement guestRequestElement = (from req in guestRequestRoot.Elements()
//                                            where int.Parse(req.Element("id").Value) == guestRequestNumber
//                                            select req).FirstOrDefault();
//            guestRequestElement.Element("status").Value = status.ToString();
//            guestRequestRoot.Save(guestRequestPath);
//        }
//        #endregion

//        #region hosting unit methods
//        public void AddHostingUnit(HostingUnit hostingUnit)
//        {
//            throw new NotImplementedException();

//            //hostingUnit.HostingUnitKey = GetHostingUnitKey();
//            //hostingUnitRoot.Add(new XElement("hostingUnit",
//            //    new XElement("id", hostingUnit.HostingUnitKey),
//            //    new XElement("name", hostingUnit.HostingUnitName),
//            //    new XElement("extras", new XElement("pool", hostingUnit.HasPool), new XElement("garden", hostingUnit.HasGarden), new XElement("groceryStore", hostingUnit.HasNearByGroceryStore), new XElement("attractions", hostingUnit.HasChildrensAttractions)),
//            //    new XElement("status", guestRequest.Status),
//            //    new XElement("area", guestRequest.Area),
//            //    new XElement("mail", guestRequest.MailAddress),
//            //    new XElement("dates", new XElement("registrationDate", guestRequest.RegistrationDate), new XElement("entryDate", guestRequest.EntryDate), new XElement("releaseDate", guestRequest.ReleaseDate))
//            //    ));
//            //guestRequestRoot.Save(guestRequestPath);
//        }

//        public void DeleteHostingUnit(int hotingUnitNumber)
//        {
//            throw new NotImplementedException();
//        }

//        public void UpdateHostingUnit(HostingUnit hostingUnit)
//        {
//            throw new NotImplementedException();
//            //XElement guestRequestElement = (from req in guestRequestRoot.Elements()
//            //                                where int.Parse(req.Element("id").Value) == guestRequestNumber
//            //                                select req).FirstOrDefault();
//            //guestRequestElement.Element("status").Value = status.ToString();
//            //guestRequestRoot.Save(guestRequestPath);
//        }
//        #endregion

//        #region order methods
//        public void AddOrder(Order order)
//        {
//            order.OrderKey = GetOrderKey();
//            guestRequestRoot.Add(new XElement("order",
//                new XElement("id", order.OrderKey),
//                new XElement("foreignKeys", new XElement("guestRequestId", order.GuestRequestKey), new XElement("hostingUnitId", order.HostingUnitKey)),
//                new XElement("status", order.Status),
//                new XElement("dates", new XElement("creationDate", order.CreateDate), new XElement("orderDate", order.OrderDate))
//                ));
//            guestRequestRoot.Save(guestRequestPath);
//        }

//        public void deleteOrder(int orderKey)
//        {
//            XElement orderElement = (from ord in orderRoot.Elements()
//                                     where int.Parse(ord.Element("id").Value) == orderKey
//                                     select ord).FirstOrDefault();
//            orderElement.Remove();
//            orderRoot.Save(orderPath);
//        }

//        public void UpdateOrder(int orderNumber, OrderStatus status)
//        {
//            XElement orderElement = (from ord in orderRoot.Elements()
//                                     where int.Parse(ord.Element("id").Value) == orderNumber
//                                     select ord).FirstOrDefault();
//            orderElement.Element("status").Value = status.ToString();
//            orderRoot.Save(orderPath);
//        }
//        #endregion

//        #region getAll methods
//        public IEnumerable<BankBranch> GetAllBankBranches()
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<GuestRequest> GetAllGuestReuests()
//        {
//            return from req in guestRequestRoot.Elements()
//                   select new GuestRequest()
//                   {
//                       GuestRequestKey = int.Parse(req.Element("id").Value),
//                       Adults = int.Parse(req.Element("guests").Element("adults").Value),
//                       Children = int.Parse(req.Element("guests").Element("children").Value),
//                       PrivateName = req.Element("name").Element("firstName").Value,
//                       FamilyName = req.Element("name").Element("familyName").Value,
//                       MailAddress = req.Element("mail").Value,
//                       Status = (GuestRequestStatus)Enum.Parse(typeof(GuestRequestStatus), req.Element("status").Value),
//                       Area = (AreaOfTheCountry)Enum.Parse(typeof(AreaOfTheCountry), req.Element("area").Value),
//                       Pool = (AmountOfIntrenst)Enum.Parse(typeof(AmountOfIntrenst), req.Element("extras").Element("pool").Value),
//                       Garden = (AmountOfIntrenst)Enum.Parse(typeof(AmountOfIntrenst), req.Element("extras").Element("garden").Value),
//                       ChildrensAttractions = (AmountOfIntrenst)Enum.Parse(typeof(AmountOfIntrenst), req.Element("extras").Element("attractions").Value),
//                       CloseByGroceryStore = (AmountOfIntrenst)Enum.Parse(typeof(AmountOfIntrenst), req.Element("extras").Element("groceryStore").Value),
//                       RegistrationDate = DateTime.Parse(req.Element("dates").Element("registrationDate").Value),
//                       EntryDate = DateTime.Parse(req.Element("dates").Element("entryDate").Value),
//                       ReleaseDate = DateTime.Parse(req.Element("dates").Element("releaseDate").Value)
//                   }.Clone();
//        }

//        public IEnumerable<HostingUnit> GetAllHostingUnits()
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Order> GetAllOrders()
//        {
//            throw new NotImplementedException();
//        }
//        #endregion

//        #region get item by id 
//        public GuestRequest GetGuestRequest(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public HostingUnit GetHostingUnit(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Order GetOrder(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public int GetTotalEarnings()
//        {
//            throw new NotImplementedException();
//        }

//        #endregion

//        #region site owner methods
//        public void CollectFee(int dayCount)
//        {
//            throw new NotImplementedException();
//        }
//        #endregion

//        #region bankAccount

//        #endregion

//        #region configuration
//        int GetGuestRequestKey()
//        {
//            int old = int.Parse(configRoot.Element("guestRequestCounter").Value);
//            configRoot.Element("guestRequestCounter").Value = (old + 1).ToString();
//            configRoot.Save(configPath);
//            return old;
//        }

//        int GetHostingUnitKey()
//        {
//            int old = int.Parse(configRoot.Element("hostingUnitCounter").Value);
//            configRoot.Element("hostingUnitCounter").Value = (old + 1).ToString();
//            configRoot.Save(configPath);
//            return old;
//        }

//        int GetOrderKey()
//        {
//            int old = int.Parse(configRoot.Element("orderCounter").Value);
//            configRoot.Element("orderCounter").Value = (old + 1).ToString();
//            configRoot.Save(configPath);
//            return old;
//        }
//        #endregion

//        #region thread
//        private static void getBanks()
//        {
//            bool downloadedSuccefully = false;
//            WebClient wc = new WebClient();
//            while (!downloadedSuccefully)
//            {
//                try
//                {

//                    string xmlServerPath = @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
//                    wc.DownloadFile(xmlServerPath, xmlLocalPath);
//                    downloadedSuccefully = true;
//                }
//                catch (Exception)
//                {
//                    string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
//                    wc.DownloadFile(xmlServerPath, xmlLocalPath);
//                    downloadedSuccefully = true;
//                }
//                finally
//                {
//                    downloadedSuccefully = false;
//                    wc.Dispose();
//                    Thread.Sleep(1000);
//                }
//            }
//        }

//        public bool IsDoneDownlloadingBanks()
//        {
//            if(getBankAccounts.IsAlive)
//            {
//                return false;
//            }
//            return true;
//        }
//        #endregion


//        //#region serialize functions
//        //public static void SaveToXML<T>(T source, string path)
//        //{
//        //    FileStream file = new FileStream(path, FileMode.Create);
//        //    XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
//        //    xmlSerializer.Serialize(file, source);
//        //    file.Close();
//        //}
//        //public static T LoadFromXML<T>(string path)
//        //{
//        //    FileStream file = new FileStream(path, FileMode.Open);
//        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
//        //    T result = (T)xmlSerializer.Deserialize(file);
//        //    file.Close();
//        //    return result;
//        //}
//        //#endregion
//    }
//}



////using BE;
////using System;
////using System.Collections.Generic;
////using System.ComponentModel;
////using System.IO;
////using System.Linq;
////using System.Reflection;
////using System.Net;
////using System.Text;
////using System.Threading.Tasks;
////using System.Xml.Linq;
////using System.Threading;
////using System.Xml.Serialization;
////using DS;

////namespace DAL
////{
////    class imp_XML_D : IDAL
////    {

////        XElement banksRoot;
////        string banksPath = @"..\..\..\xmlFile\atm.xml";

////        string hostingUnitPath = @"..\..\..\xmlFile\hostingUnitXml.xml";

////        XElement guestRequestRoot;
////        string guestRequestPath = @"..\..\..\xmlFile\guestRequestXml.xml";
////        XElement orderRoot;
////        string orderPath = @"..\..\..\xmlFile\orderXml.xml";
////        XElement configRoot;
////        string configPath = @"..\..\..\xmlFile\configXml.xml";
////        public imp_XML_D()
////        {

////            if (!File.Exists(hostingUnitPath))
////            {
////                FileStream fileHostingUnit = new FileStream(hostingUnitPath, FileMode.Create);
////                fileHostingUnit.Close();
////            }
////            else
////                DataSource.HostingUnitslist = (loadListFromXML<HostingUnit>(hostingUnitPath));
////            if (!File.Exists(configPath))
////            {
////                configRoot = new XElement("Configuration");
////                XElement idGuestRequest = new XElement("idGuestRequest", 10000001);
////                XElement idHostingUnit = new XElement("idHostingUnit", 10000003);
////                XElement idOrder = new XElement("idOrder", 10000001);
////                XElement sum = new XElement("sum", 0);
////                XElement password = new XElement("password", 1234);
////                configRoot.Add(idGuestRequest);
////                configRoot.Add(idHostingUnit);
////                configRoot.Add(idOrder);
////                configRoot.Add(sum);
////                configRoot.Add(password);
////                configRoot.Save(configPath);

////            }
////            else
////            {
////                configRoot = XElement.Load(configPath);
////                Configuration.password = Convert.ToString(configRoot.Element("password").Value);
////                Configuration.sum = Convert.ToInt32(configRoot.Element("sum").Value);
////            }

////            try
////            {
////                guestRequestRoot = XElement.Load(guestRequestPath);
////            }
////            catch
////            {
////                guestRequestRoot = new XElement("GuestRequest");
////                guestRequestRoot.Save(guestRequestPath);
////            }
////            try
////            {
////                orderRoot = XElement.Load(orderPath);
////            }
////            catch
////            {
////                orderRoot = new XElement("Order");
////                orderRoot.Save(orderPath);
////            }

////            if (!File.Exists(banksPath))
////            {
////                WebClient wc = new WebClient();
////                try
////                {
////                    string xmlServerPath =
////                  @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
////                    wc.DownloadFile(xmlServerPath, banksPath);
////                }
////                catch (Exception)
////                {
////                    string xmlServerPath = @"https://drive.google.com/file/d/1FpcqslnRD6naLHOjrCvKArCg3Ihkb9hR/view?usp=sharing";
////                    wc.DownloadFile(xmlServerPath, banksPath);
////                }
////                finally
////                {
////                    wc.Dispose();
////                }
////            }
////            else
////            {
////                banksRoot = XElement.Load(banksPath);
////            }
////            saveListToXML<HostingUnit>(DataSource.HostingUnitslist, hostingUnitPath);
////        }
////        #region convertsFuncs     
////        BankBranch ConvertBankBranch(XElement element)
////        {
////            return new BankBranch()
////            {
////                BankNumber = int.Parse(element.Element("קוד_בנק").Value),
////                BankName = element.Element("שם_בנק").Value,
////                BranchNumber = int.Parse(element.Element("קוד_סניף").Value),
////                BranchAddress = element.Element("כתובת_ה-ATM").Value,
////                BranchCity = element.Element("ישוב").Value
////            };
////        }

////        Host ConvertHost(XElement element)
////        {
////            Host host = new Host();
////            foreach (PropertyInfo item in typeof(Host).GetProperties())
////            {
////                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
////                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);
////                if (item.CanWrite)
////                    item.SetValue(host, convertValue);
////            }
////            return host;
////        }
////        HostingUnit ConvertHostingUnit(XElement element)
////        {
////            HostingUnit hostingUnit = new HostingUnit();
////            foreach (PropertyInfo item in typeof(HostingUnit).GetProperties())
////            {

////                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
////                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);
////                if (item.CanWrite)
////                    item.SetValue(hostingUnit, convertValue);
////            }
////            return hostingUnit;
////        }
////        GuestRequest ConvertGuestRequest(XElement element)
////        {
////            GuestRequest guestRequest = new GuestRequest();
////            foreach (PropertyInfo item in typeof(GuestRequest).GetProperties())
////            {
////                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
////                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);
////                if (item.CanWrite)
////                    item.SetValue(guestRequest, convertValue);
////            }
////            return guestRequest;
////        }
////        Order ConvertOrder(XElement element)
////        {
////            Order order = new Order();
////            foreach (PropertyInfo item in typeof(Order).GetProperties())
////            {
////                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
////                object convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);
////                if (item.CanWrite)
////                    item.SetValue(order, convertValue);
////            }
////            return order;
////        }

////        XElement ConvertHostingUnit(HostingUnit hostingUnit)
////        {
////            XElement hostingUnitElement = new XElement("hostingUnit");
////            foreach (PropertyInfo item in typeof(HostingUnit).GetProperties())
////                hostingUnitElement.Add
////                    (
////                    new XElement(item.Name, item.GetValue(hostingUnit, null).ToString())
////                    );
////            return hostingUnitElement;
////        }
////        XElement ConvertGuestRequest(GuestRequest guestRequest)
////        {
////            XElement guestRequestElement = new XElement("GuestRequest");
////            foreach (PropertyInfo item in typeof(GuestRequest).GetProperties())
////                guestRequestElement.Add
////                    (
////                    new XElement(item.Name, item.GetValue(guestRequest, null).ToString())
////                    );
////            return guestRequestElement;
////        }

////        XElement ConvertOrder(Order order)
////        {
////            XElement orderElement = new XElement("order");
////            foreach (PropertyInfo item in typeof(Order).GetProperties())
////                orderElement.Add
////                    (
////                    new XElement(item.Name, item.GetValue(order, null).ToString())
////                    );
////            return orderElement;
////        }
////        public static void saveListToXML<T>(List<T> list, string Path)
////        {
////            FileStream file = new FileStream(Path, FileMode.Create);
////            XmlSerializer x = new XmlSerializer(list.GetType());
////            x.Serialize(file, list);
////            file.Close();
////        }
////        public static List<T> loadListFromXML<T>(string path)
////        {
////            if (File.Exists(path))
////            {
////                FileStream file = new FileStream(path, FileMode.Open);
////                XmlSerializer x = new XmlSerializer(typeof(List<T>));
////                List<T> list = (List<T>)x.Deserialize(file);
////                file.Close();
////                return list;
////            }
////            else return new List<T>();
////        }
////        #endregion
////        #region hostingUnitsfuncs
////        public void addHostingUnit(HostingUnit hostingUnit)
////        {

////            long hostingKey = Convert.ToInt64(configRoot.Element("idHostingUnit").Value);
////            DS.DataSource.HostingUnitslist = (loadListFromXML<HostingUnit>(hostingUnitPath));
////            if (hostingUnit.HostingUnitKey == 0)
////            {
////                hostingUnit.HostingUnitKey = hostingKey++;
////            }

////            DataSource.HostingUnitslist.Add(hostingUnit);
////            saveListToXML<HostingUnit>(DataSource.HostingUnitslist, hostingUnitPath);
////            configRoot.Element("idHostingUnit").Value = hostingKey.ToString();
////            configRoot.Save(configPath);

////        }

////        public void deleteHostingUnit(long Hkey)
////        {
////            DataSource.HostingUnitslist = (loadListFromXML<HostingUnit>(hostingUnitPath));
////            DataSource.HostingUnitslist.RemoveAll(x => x.HostingUnitKey == Hkey);
////            saveListToXML<HostingUnit>(DataSource.HostingUnitslist, hostingUnitPath);
////        }
////        public void appdateHostingUnit(HostingUnit hostingUnit)
////        {
////            DataSource.HostingUnitslist = (loadListFromXML<HostingUnit>(hostingUnitPath));
////            DataSource.HostingUnitslist.RemoveAll(x => x.HostingUnitKey == hostingUnit.HostingUnitKey);
////            DataSource.HostingUnitslist.Add(hostingUnit);
////            saveListToXML<HostingUnit>(DataSource.HostingUnitslist, hostingUnitPath);
////        }
////        private HostingUnit GetHostingUnit(long key)
////        {
////            DataSource.HostingUnitslist = (loadListFromXML<HostingUnit>(hostingUnitPath));
////            int index = DS.DataSource.HostingUnitslist.FindIndex(t => t.HostingUnitKey == key);
////            if (index == -1)
////            {
////                throw new Exception("there is no hostging unit with the key:" + key + " (DAL)\n");
////            }
////            BE.HostingUnit a = (DS.DataSource.HostingUnitslist[index]).Clone();
////            return a;
////        }
////        #endregion
////        #region guestRequestFuncs
////        public void addGuestRequest(GuestRequest gr)
////        {

////            long c = Convert.ToInt64(configRoot.Element("idGuestRequest").Value);
////            gr.GuestRequestKey = c++;
////            configRoot.Element("idGuestRequest").Value = Convert.ToString(c);
////            configRoot.Save(configPath);
////            guestRequestRoot.Add(ConvertGuestRequest(gr));
////            guestRequestRoot.Save(guestRequestPath);
////        }
////        private GuestRequest GetGuestRequest(long GuestRequestKey)
////        {
////            XElement g = null;
////            try
////            {
////                g = (from item in guestRequestRoot.Elements()
////                     where int.Parse(item.Element("GuestRequestKey").Value) == GuestRequestKey
////                     select item).FirstOrDefault();
////            }
////            catch (Exception)
////            {
////                return null;
////            }
////            if (g == null)
////                return null;
////            return ConvertGuestRequest(g);
////        }
////        public void appdateGuestRequest(GuestRequest req)
////        {
////            XElement toUpdate = (from item in guestRequestRoot.Elements()
////                                 where int.Parse(item.Element("GuestRequestKey").Value) == req.GuestRequestKey
////                                 select item).FirstOrDefault();
////            if (toUpdate == null)
////                throw new Exception("guestRequest to update doesn't exist");
////            foreach (PropertyInfo item in typeof(GuestRequest).GetProperties())
////                toUpdate.Element(item.Name).SetValue(item.GetValue(req).ToString());
////            guestRequestRoot.Save(guestRequestPath);
////        }
////        #endregion
////        #region orderFuncs
////        public void addOrder(Order or)
////        {
////            long c = Convert.ToInt64(configRoot.Element("idOrder").Value);
////            or.OrderKey = c++;
////            configRoot.Element("idOrder").Value = Convert.ToString(c);
////            configRoot.Save(configPath);
////            orderRoot.Add(ConvertOrder(or));
////            orderRoot.Save(orderPath);

////        }

////        private Order GetOrder(long OrderKey)
////        {
////            XElement o = null;
////            try
////            {
////                o = (from item in orderRoot.Elements()
////                     where int.Parse(item.Element("OrderKey").Value) == OrderKey
////                     select item).FirstOrDefault();
////            }
////            catch (Exception)
////            {
////                return null;
////            }
////            if (o == null)
////                return null;
////            return ConvertOrder(o);
////        }
////        public void appdateOrder(Order or)
////        {
////            XElement toUpdate = (from item in orderRoot.Elements()
////                                 where int.Parse(item.Element("OrderKey").Value) == or.OrderKey
////                                 select item).FirstOrDefault();
////            if (toUpdate == null)
////                throw new Exception("Order to update doesn't exist");
////            foreach (PropertyInfo item in typeof(Order).GetProperties())
////                toUpdate.Element(item.Name).SetValue(item.GetValue(or).ToString());
////            orderRoot.Save(orderPath);
////        }
////        #endregion
////        #region lists
////        public List<BankBranch> BankBranchDetailsList()
////        {
////            return ((from item in banksRoot.Elements()
////                     let a = ConvertBankBranch(item)
////                     select a)).ToList();
////        }
////        public List<HostingUnit> HostingUnitsList()
////        {
////            DataSource.HostingUnitslist = loadListFromXML<HostingUnit>(hostingUnitPath);
////            return (from x in DataSource.HostingUnitslist select x).ToList();

////        }
////        public List<GuestRequest> guestRequestsList()
////        {
////            return (from item in guestRequestRoot.Elements()
////                    select ConvertGuestRequest(item)).ToList();
////        }
////        public List<Order> ordersList()
////        {
////            return (from item in orderRoot.Elements()
////                    select ConvertOrder(item)).ToList();
////        }
////        #endregion
////        public void changePassword()
////        {
////            configRoot.Element("password").Value = Configuration.password;
////            configRoot.Save(configPath);
////        }
////        public void changeSum()
////        {
////            configRoot.Element("sum").Value = Convert.ToString(Configuration.sum);
////            configRoot.Save(configPath);
////        }