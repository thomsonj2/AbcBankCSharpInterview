using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank
{
    public class CheckingAccount : Account
    {
        public override AccountType getAccountType()
        {
            return AccountType.CheckingAccount;
        }

        public override decimal InterestCalculation()
        {
            throw new NotImplementedException();
        }
    }
}
