using System;
using BE;
using BL;
using System.Linq;
namespace PL
{
    class Program
    {
        static IBL myIbl = FactoryBL.GetBL();
        static void Main(string[] args)
        {
            //add guests
            myIbl.AddGuestRequest(
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

            myIbl.AddGuestRequest(
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

            myIbl.AddGuestRequest(
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
            myIbl.AddHostingUnit(
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

            myIbl.AddHostingUnit(
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


            char choice = 'a';
            while (choice != 'q')
            {
                PrintOptions();
                choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case 'a':
                        PrintAllGuestRequests();
                        break;
                    case 'b':
                        PrintAllHostingUnit();
                        break;
                    case 'c':
                        AddOrder();
                        break;
                    case 'd':
                        PrintAllOrders();
                        break;
                    case 'e':
                        SendMail();
                        break;
                    case 'f':
                        ChangeOrderStatus();
                        break;
                    case 'g':
                        SignCollectionClearance();
                        break;
                    case 'q':
                        break;
                    default:
                        Console.WriteLine("invalid output");
                        break;
                }
            }
        }

        private static void SignCollectionClearance()
        {
            int unitKey;
            try
            {
                Console.WriteLine("enter the hostingUnit you wish to sign collectionClearance for:\n");
                unitKey = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("invalid input\n");
                return;
            }
            HostingUnit unit = (from hUnit in myIbl.GetAllHostingUnits()
                               where hUnit.HostingUnitKey == unitKey
                               select hUnit).First();

            if (unit == null)
            {
                Console.WriteLine("not existing hostingUnit\n");
                return;
            }

            unit.Owner.CollectionClearance = Y_N.Yes;
            try
            {
                myIbl.UpdateHostingUnit(unit);
            }
            catch (Exception)
            {
                Console.WriteLine("updateHostingUnit didnt work\n");
                return;
            }
        }

        private static void SendMail()
        {
            int key;
            try
            {
                Console.WriteLine("Please enter the key of the Order you wish to send:\n");
                key = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("invalid input\n");
                return;
            }

            var Myorder = (from or in myIbl.GetAllOrders()
                        where or.HostingUnitKey == key
                        select or).First();

            if (Myorder == null)
            {
                Console.WriteLine("not existing order\n");
                return;
            }
            try
            {
                myIbl.UpdateOrder(key, OrderStatus.MailWasSent);
            }
            catch (Exception)
            {
                Console.WriteLine("update order did not work either no collectionClearance or status is DealWasClosed\n");
                return;
            }
            Console.WriteLine("mail was sent\n");
           
        }

        private static void ChangeOrderStatus()
        {
            PrintAllOrders();
            int orderKey;
            try
            {
                Console.WriteLine("enter the order id to update\n");
                orderKey = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

                Console.WriteLine("invalid input\n");
                return;
            }
            try
            {
                myIbl.UpdateOrder(orderKey, OrderStatus.DealWasClosed);
            }
            catch (Exception)
            {
                Console.WriteLine("updateOrder didnt work either because the dates are occupied or deal was closed or there is a status exception\n");
                return;
            }
            
        }

        private static void AddOrder()
        {
            int guestID, UnitID;
            PrintAllGuestRequests();

            try
            {
                Console.WriteLine("enter the id of the guestRequest you wish to add:\n");
                guestID = int.Parse(Console.ReadLine());
                Console.WriteLine("enter the ID of the HostingUnit you wish to connect to the request:\n");
                UnitID = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("you didnt enter a good input\n");
                return;
            }


            var unit = (from HostingUnit hostingUnit in myIbl.GetAllHostingUnits()
                       where hostingUnit.HostingUnitKey == UnitID
                       select hostingUnit).First();
                       

            var guest = (from GuestRequest guestRequest in myIbl.GetAllGuestReuests()
                        where guestRequest.GuestRequestKey == guestID
                        select guestRequest).First();

            if (unit == null || guest == null)
            {
                Console.WriteLine("not existing id\n");
                return;
            }
            Order newOrder = new Order()
            {
                HostingUnitKey = UnitID,
                GuestRequestKey = guestID,
                CreateDate = DateTime.Today,
                Status = OrderStatus.YetToBeAttendedTo,
            };
            try
            {
                myIbl.AddOrder(newOrder);
            }
            catch (Exception)
            {
                Console.WriteLine("the hosting unit is occupied in these dates or there is a stauts exception\n");
                return;
            }

        }



        static void PrintOptions()
        {
            Console.WriteLine("__________________________________\n");
            Console.WriteLine("Choose an option:\n");         
            Console.WriteLine("a: print all guest request\n");
            Console.WriteLine("b: print all the hosting units\n");
            Console.WriteLine("c: add an order\n");
            Console.WriteLine("d: print all orders\n");
            Console.WriteLine("e: send mail\n");
            Console.WriteLine("f: change order status\n");
            Console.WriteLine("g: sign collection clearance\n");
            Console.WriteLine("q: quit\n");
            Console.WriteLine("__________________________________\n");
        }

        #region PrintAll functions
        private static void PrintAllOrders()
        {
            try
            {
                foreach (var item in myIbl.GetAllOrders())
                {
                    Console.WriteLine("{0}\n", item);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("PrintAllOrders didn't work\n");
            }
        }


        private static void PrintAllHostingUnit()
        {
            try
            {
                foreach (var item in myIbl.GetAllHostingUnits())
                {
                    Console.WriteLine("{0}\n", item);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("GetAllHostingUnits didn't work\n");
            }
        }


        private static void PrintAllGuestRequests()
        {
            try
            {
                foreach (var item in myIbl.GetAllGuestReuests())
                {
                    Console.WriteLine("{0}\n", item);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("GetAllGuestReuests didn't work\n");
            }
        }
        #endregion
    }
}









