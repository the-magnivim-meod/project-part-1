using System;
using System.Collections.Generic;
using System.Text; 

namespace BE
{
    public class GuestRequest
    {
        public int GuestRequestKey;
        public string PrivateName;
        public string FamilyName;
        public string MailAddress;
        public GuestRequestStatus Status;
        public DateTime RegistrationDate;
        public DateTime EntryDate;
        public DateTime ReleaseDate;
        public AreaOfTheCountry Area;
        public HostingUnitType Type;
        public int Adults;
        public int Children;
        public AmountOfIntrenst Pool;
        public AmountOfIntrenst CloseByGroceryStore;
        public AmountOfIntrenst Garden;
        public AmountOfIntrenst ChildrensAttractions;

        
        public override string ToString()
        {
            string output = $"GuestRequestNumber: {GuestRequestKey}\n";
            output += "______________________________________________\n";
            output += $"name: {PrivateName} {FamilyName}\n";
            output += $"request status: {Status}\n";
            output += $"mail address: {MailAddress}\n";
            output += $"registration date: {RegistrationDate}\n";
            output += $"hosting unit occupation: {EntryDate}-{ReleaseDate}\n";
            output += $"Area: {Area}\n";
            output += $"Hosting unit type: {Type}\n";
            output += $"number of guests: {Adults} adults and {Children} children\n";
            output += $"extras: pool:{Pool} grocery:{CloseByGroceryStore} garden:{Garden} attractions for children:{ChildrensAttractions}\n";
            return output;
        }


    }
}
