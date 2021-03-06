﻿using System;
using System.Collections.Generic;
using System.Text;
using BE;
namespace BL
{
    static class Cloning
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
            target.Owner = original.Owner.Clone();
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
            target.MailAddress = original.MailAddress;
            target.PhoneNumber = original.PhoneNumber;
            target.PrivateName = original.PrivateName;
            target.FamilyName = original.FamilyName;
            target.BankAccountNumber = original.BankAccountNumber;
            target.BankBranchDetails = original.BankBranchDetails;
            target.CollectionClearance = original.CollectionClearance;
            target.UserName = original.UserName;
            target.Password = original.Password;
            target.RegistrationDate = original.RegistrationDate;
            target.PhoneNumber = original.PhoneNumber;
            target.Type = original.Type;
            return target;
        }

        public static Guest Clone(this Guest original)
        {
            if (original == null)
            {
                return null;
            }
            Guest target = new Guest();
            target.UserName = original.UserName;
            target.Password = original.Password;
            target.PrivateName = original.PrivateName;
            target.FamilyName = original.FamilyName;
            target.Type = original.Type;
            target.RegistrationDate = original.RegistrationDate;
            target.MailAddress = original.MailAddress;
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

        public static Admin Clone(this Admin original)
        {
            if (original == null)
            {
                return null;
            }
            Admin target = new Admin();
            target.UserName = original.UserName;
            target.Password = original.Password;
            target.PrivateName = original.PrivateName;
            target.FamilyName = original.FamilyName;
            target.Type = original.Type;
            target.RegistrationDate = original.RegistrationDate;
            target.MailAddress = original.MailAddress;
            return target;
        }
    }
}
