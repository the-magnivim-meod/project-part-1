using System;
using BE;
using BL;
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
                type = HostingUnitType.Hotel,
                Owner = new Host()
                {
                    BankAccountNumber = 1234,
                    CollectionClearance = Y_N.No,
                    PrivateName = "Amos",
                    FamilyName = "artzi",
                    BankBranchDetails = new BankBranch(),
                    PhoneNumber = "053-4723-327",
                    HostKey = 1,
                    MailAddress = "amosss@yahoo.il"
                }              
            });

            myIbl.AddHostingUnit(
            new HostingUnit()
            {
                HostingUnitName = "ZimmerSha've",
                type = HostingUnitType.Hotel,
                Owner = new Host()
                {
                    BankAccountNumber = 3839,
                    CollectionClearance = Y_N.No,
                    PrivateName = "Hadas",
                    FamilyName = "Yoff",
                    BankBranchDetails = new BankBranch(),
                    PhoneNumber = "059-7809-363",
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
                        AddOrder(1,1);
                        break;
                    case 'd':
                        PrintAllOrders();
                        break;
                    case 'q':
                        break;
                    default:
                        //throw exception
                        break;
                }
            }
        }

        private static void AddOrder(int guestRequestNumber, int hostingUnitNumber)
        {
            //not sure what to do
        }

        static void PrintOptions()
        {
            Console.WriteLine("Choose an option:\n");
            Console.WriteLine("__________________\n");
            Console.WriteLine("a: print all guest request\n");
            Console.WriteLine("b: print all the hosting units\n");
            Console.WriteLine("c: add an order\n");
            Console.WriteLine("d: print all orders\n");
            Console.WriteLine("q: quit\n");
        }

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

    }
}









