using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class BankBranch
    {
        int BankNumber;
        string BankName;
        int BranchNumber;
        string BranchAddress;//optional add class address
        string BranchCity;//optional add enum city
        int BankAccountNumber;

        
        public override string ToString()
        {
            string output = $"the {BankName} bank, number{BankNumber}\n";
            output = $"branch: number-{BranchNumber}, city-{BranchCity}, address-{BranchAddress}\n";
            return output;
        }
    }
}
