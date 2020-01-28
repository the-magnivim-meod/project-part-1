using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Host : User
    {
        public int HostKey { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public BankBranch BankBranchDetails { get; set; }
        public int BankAccountNumber { get; set; }
        public Y_N CollectionClearance { get; set; }
        public override string ToString()
        {
            string output = "HostKey:" + HostKey + "\n";
            output += "Name: " + PrivateName + " " + FamilyName + "\n";
            output += "phoneNumber: " + PhoneNumber + "\n";
            output += "MailAddress: " + MailAddress + "\n";
            output += $"{BankBranchDetails}";
            output += $"account number: {BankAccountNumber}\n";
            output += $"CollectionClearance {CollectionClearance} \n";
            return output;
        }
    }
}
