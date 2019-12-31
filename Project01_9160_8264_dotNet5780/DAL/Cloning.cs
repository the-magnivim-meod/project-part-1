using BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public static class Cloning
    {
        /// <summary>
        /// create a copy instance with the same values
        /// </summary>
        /// <param name="original">original item</param>
        /// <returns>copy of item</returns>
        public static GuestRequest Clone(this GuestRequest original)
        {
            GuestRequest target = new GuestRequest();
            target.GuestRequestKey = original.GuestRequestKey;
            target.PrivateName = original.PrivateName;
            target.FamilyName = original.FamilyName;
            target.MailAddress = original.MailAddress;
            target.Status = original.Status;
            target.RegistrationDate = original.RegistrationDate;
            target.EntryDate = original.EntryDate;
            target.ReleaseDate = original.ReleaseDate;
            target.Area = original.Area;
            target.Type = original.Type;
            target.Adults = original.Adults;
            target.Children = original.Children;
            target.Pool = original.Pool;
            target.CloseByGroceryStore = original.CloseByGroceryStore;
            target.Garden = original.Garden;
            target.ChildrensAttractions = original.ChildrensAttractions;
            return target;
        }

        /// <summary>
        /// create a copy instance with the same values
        /// </summary>
        /// <param name="original">original item</param>
        /// <returns>copy of item</returns>
        public static Order Clone(this Order original)
        {
            Order target = new Order();
            target.HostingUnitKey = original.HostingUnitKey;
            target.GuestRequestKey = original.GuestRequestKey;
            target.OrderKey = original.OrderKey;
            target.Status = original.Status;
            target.OrderDate = original.OrderDate;
            target.CreateDate = original.CreateDate;
            return target;
        }

        /// <summary>
        /// create a copy instance with the same values
        /// </summary>
        /// <param name="original">original item</param>
        /// <returns>copy of item</returns>
        public static HostingUnit Clone(this HostingUnit original)
        {
            HostingUnit target = new HostingUnit();
            target.HostingUnitKey = original.HostingUnitKey;
            target.Owner= original.Owner;
            target.HostingUnitName = original.HostingUnitName;
            target.Diary = original.Diary;
            return target;
        }
    }
}