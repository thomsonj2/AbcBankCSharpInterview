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
            return AccountType.Savings;
        }

        public override decimal InterestCalculation()
        {
            if (AccountBalance <= 1000)
                return AccountBalance * 0.001m / 365;
            else
                return (1000 * 0.001m + (AccountBalance - 1000) * 0.002m) / 365;
        }
    }
}
