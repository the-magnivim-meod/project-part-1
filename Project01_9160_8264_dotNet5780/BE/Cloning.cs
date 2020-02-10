﻿using BE;
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
            if (original == null)
            {
                return null;
            }
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
            if (original == null)
            {
                return null;
            }
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
            if (original == null)
            {
                return null;
            }
            HostingUnit target = new HostingUnit();
            target.HostingUnitKey = original.HostingUnitKey;
            target.Owner= original.Owner.Clone();
            target.HostingUnitName = original.HostingUnitName;
            target.Diary = original.Diary;
            target.Type = original.Type;
            target.Area = original.Area;
            target.HasGarden = original.HasGarden;
            target.HasNearByGroceryStore = original.HasNearByGroceryStore;
            target.HasPool = original.HasPool;
            target.HasChildrensAttractions = original.HasChildrensAttractions;
            return target;
        }

        public static Host Clone(this Host original)
        {
            if (original == null)
            {
                return null;
            }
            Host target = new Host();
            target.HostKey = original.HostKey;
            target.MailAddress = original.MailAddress;
            target.PhoneNumber = original.PhoneNumber;
            target.PrivateName = original.PrivateName;
            target.FamilyName = original.FamilyName;
            target.BankAccountNumber = original.BankAccountNumber;
            target.BankBranchDetails = original.BankBranchDetails;
            target.CollectionClearance = original.CollectionClearance;
            return target;
        }

        public static BankBranch Clone(this BankBranch original)
        {
            if (original == null)
            {
                return null;
            }
            BankBranch target = new BankBranch();
            target.BankName = original.BankName;
            target.BankAccountNumber = original.BankAccountNumber;
            target.BankNumber = original.BankNumber;
            target.BranchAddress = original.BranchAddress;
            target.BranchCity = original.BranchCity;
            target.BranchNumber = original.BranchNumber;
            return target;
        }
    }
}