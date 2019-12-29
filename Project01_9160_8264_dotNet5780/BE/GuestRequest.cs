using System;
using System.Collections.Generic;
using System.Text; 

namespace BE
{
    public class GuestRequest
    {
        int GuestRequestKey;
        string PrivateName;
        string FamilyName;
        string MailAddress;
        OrderStatus Status;
        DateTime RegistrationDate;
        DateTime EntryDate;
        DateTime ReleaseDate;
        AreaOfTheCountry Area;
        HostingUnitType Type;
        int Adults;
        int Children;
        AmountOfIntrenst Pool;
        AmountOfIntrenst CloseByGroceryStore;
        AmountOfIntrenst Garden;
        AmountOfIntrenst ChildrensAttractions;

        
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
