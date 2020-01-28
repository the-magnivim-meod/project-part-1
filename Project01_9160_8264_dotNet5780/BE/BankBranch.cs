using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class BankBranch
    {
        public int BankNumber { get; set; }
        public string BankName { get; set; }
        public int BranchNumber { get; set; }
        public string BranchAddress { get; set; }//optional add class address
        public string BranchCity { get; set; }//optional add enum city
        public int BankAccountNumber { get; set; }


        public override string ToString()
        {
            string output = $"the {BankName} bank, number:{BankNumber}\n";
            output = $"branch: number-{BranchNumber}, city-" + BranchCity + ", address-" + BranchAddress + "\n";
            return output;
        }
    }
}
