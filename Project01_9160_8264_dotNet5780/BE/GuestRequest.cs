using System;
using System.Collections.Generic;
using System.Text; 

namespace BE
{
    public class GuestRequest
    {
        public int GuestRequestKey { get; set; }
        public string PrivateName { get; set; }
        public string FamilyName { get; set; }
        public string MailAddress { get; set; }
        public GuestRequestStatus Status { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public AreaOfTheCountry Area { get; set; }
        public HostingUnitType Type { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public AmountOfIntrenst Pool { get; set; }
        public AmountOfIntrenst CloseByGroceryStore { get; set; }
        public AmountOfIntrenst Garden { get; set; }
        public AmountOfIntrenst ChildrensAttractions { get; set; }


        public override string ToString()
        {            
            string output = $"\nGuestRequestNumber: {GuestRequestKey}\n";           
            output += $"name: {PrivateName} {FamilyName}\n";
            output += $"request status: {Status}\n";
            output += $"mail address: {MailAddress}\n";
            output += $"registration date: {RegistrationDate}\n";
            output += $"hosting unit occupation: {EntryDate}-{ReleaseDate}\n";
            output += $"Area: {Area}\n";
            output += $"Hosting unit type: {Type}\n";
            output += $"number of guests: {Adults} adults and {Children} children\n";
            output += $"extras: [pool:{Pool}], [grocery:{CloseByGroceryStore}], [garden:{Garden}], [attractions for children:{ChildrensAttractions}]\n";
            return output;
        }


    }
}
