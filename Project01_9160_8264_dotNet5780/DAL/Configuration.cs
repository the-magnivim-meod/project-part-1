﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public static class Configuration
    {
        private static int hostingUnitCounter = 1;
        private static int hostCounter = 10000000;
        private static int guestRequestCounter = 1;
        private static int orderCounter = 1;

        public static int HostingUnitCounter
        {          
            get
            {
                return hostingUnitCounter++;
            }
        }

        public static int HostCounter
        {
            get
            {
                return hostCounter++;
            }
        }

        public static int GuestRequestCounter
        {
            get
            {
                return guestRequestCounter++;
            }
        }

        public static int OrderCounter
        {
            get
            {
                return orderCounter++;
            }
        }
    }
}
