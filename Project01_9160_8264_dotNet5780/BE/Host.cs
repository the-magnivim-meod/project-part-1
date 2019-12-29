using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Host
    {
        int HostKey;
        string PrivateName;
        string FamilyName;
        int PhoneNumber;
        string MailAddress;
        BankBranch BankBranchDetails;
        int BankAccountNumber;
        Y_N CollectionClearance;
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
