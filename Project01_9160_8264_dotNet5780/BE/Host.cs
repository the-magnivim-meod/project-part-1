using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Host
    {
        public int HostKey;
        public string PrivateName;
        public string FamilyName;
        public int PhoneNumber;
        public string MailAddress;
        public BankBranch BankBranchDetails;
        public int BankAccountNumber;
        public Y_N CollectionClearance;
        public override string ToString()
        {
            string output = "HostKey:" + HostKey + "/n";
            output += "_________________________________";
            output += "PrivateName: " + PrivateName + "FamilyName" + FamilyName + "/n";
            output += "phoneNumber: " + PhoneNumber + "/n";
            output += "MailAddress: " + MailAddress + "/n";
            output += $"{BankBranchDetails}";
            output += $"account number: {BankAccountNumber}/n";
            output += $"CollectionClearance {CollectionClearance} /n";
            return output;
        }
    }
}
