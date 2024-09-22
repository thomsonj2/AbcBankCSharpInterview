using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank
{
    public class SavingsAccount : Account
    {
        public override AccountType getAccountType()
        {
            return AccountType.SavingsAccount;
        }

        public override decimal InterestCalculation()
        {
            throw new NotImplementedException();
        }
    }
}
