using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class BankBranch
    {
        public int BankNumber;
        public string BankName;
        public int BranchNumber;
        public string BranchAddress;//optional add class address
        public string BranchCity;//optional add enum city
        public int BankAccountNumber;

        
        public override string ToString()
        {
            string output = $"the {BankName} bank, number{BankNumber}\n";
            output = $"branch: number-{BranchNumber}, city-{BranchCity}, address-{BranchAddress}\n";
            return output;
        }
    }
}
