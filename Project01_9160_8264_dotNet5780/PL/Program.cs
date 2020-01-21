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
                        CloseTheDeal();
                        break;
                    case 'g':
                        SignCollectionClearance();
                        break;
                    case 'h':
                        RemoveCollectionClearance();
                        break;
                    case 'i':
                        DeleteHostingUnit();
                        break;
                    case 'j':
                        PrintTotalEarnings();
                        break;
                    case 'q':
                        break;
                    default:
                        Console.WriteLine("invalid output");
                        break;
                }
            }
        }

        private static void PrintTotalEarnings()
        {
            Console.WriteLine($"the site owner earned a total of:{myIbl.GetTotalEarnings()} NIS!!!!\n");
        }

        private static void DeleteHostingUnit()
        {
            int unitKey;
            try
            {
                Console.WriteLine("enter the hosting unit ID to delete\n");
                unitKey = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("invalid input\n");
                return;             
            }
            try
            {
                myIbl.DeleteHostingUnit(unitKey);
            }
            catch (Exception)
            {
                Console.WriteLine("DeleteHostingUnit didnt work\n");
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
                               select hUnit).FirstOrDefault();

            if (unit == null)
            {
                Console.WriteLine("not existing hostingUnit\n");
                return;
            }

            try
            {
                myIbl.SignCollectionClearance(unitKey);
            }
            catch (Exception)
            {
                Console.WriteLine("IBl.SignCollectionClearance didnt work\n");
                return;
            }
        }

        private static void RemoveCollectionClearance()
        {
            int unitKey;
            try
            {
                Console.WriteLine("enter the hostingUnit you wish to unsign collectionClearance for:\n");
                unitKey = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("invalid input\n");
                return;
            }
            HostingUnit unit = (from hUnit in myIbl.GetAllHostingUnits()
                                where hUnit.HostingUnitKey == unitKey
                                select hUnit).FirstOrDefault();

            if (unit == null)
            {
                Console.WriteLine("not existing hostingUnit\n");
                return;
            }

            try
            {
                myIbl.RemoveCollectionClearance(unitKey);
            }
            catch (Exception)
            {
                Console.WriteLine("IBl.RemoveCollectionClearance didnt work\n");
                return;
            }
        }

        private static void SendMail()
        {
            int orderKey;
            try
            {
                Console.WriteLine("Please enter the key of the Order you wish to send:\n");
                orderKey = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("invalid input\n");
                return;
            }

            try
            {
                myIbl.SendMail(orderKey);
            }
            catch (Exception)
            {
                Console.WriteLine("update order did not work\n");
                return;
            }
            Console.WriteLine("mail was sent\n");
           
        }

        private static void CloseTheDeal()
        {
            PrintAllOrders();
            int orderKey;
            try
            {
                Console.WriteLine("enter the order id you in which wish to close an order\n");
                orderKey = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {

                Console.WriteLine("invalid input\n");
                return;
            }
            try
            {
                myIbl.CloseDeal(orderKey);
            }
            catch (Exception)
            {
                Console.WriteLine("updateOrder didnt work\n");
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
                       select hostingUnit).FirstOrDefault();
                       

            var guest = (from GuestRequest guestRequest in myIbl.GetAllGuestReuests()
                        where guestRequest.GuestRequestKey == guestID
                        select guestRequest).FirstOrDefault();

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
            Console.WriteLine("f: close a deal\n");
            Console.WriteLine("g: sign collection clearance\n");
            Console.WriteLine("h: remove collection clearance\n");
            Console.WriteLine("i: delete hosting unit\n");
            Console.WriteLine("j: print total earnings\n");
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









