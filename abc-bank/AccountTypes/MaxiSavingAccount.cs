using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank
{
    public class MaxiSavingAccount : Account
    {
        public override AccountType getAccountType()
        {
            return AccountType.MaxiSavings;
        }

        public override decimal InterestCalculation()
        {
            Transaction lastWithdrawTransaction = Transactions.Where(x => x.Type == TransactionType.Withdrawal).OrderByDescending(d => d.TimeStamp).FirstOrDefault(); 
            if(lastWithdrawTransaction != null && (DateProvider.getInstance().Now() - lastWithdrawTransaction.TimeStamp ).TotalDays <= 10)
            {
                return AccountBalance * 0.001m / 365; 
            }

            if (AccountBalance <= 1000)
            {
                return AccountBalance * 0.05m / 365;
            }
            else if (AccountBalance <= 2000)
            {
                return 1000 * 0.05m + (AccountBalance - 1000) * 0.10m / 365;
            }
            else
                return (1000 * 0.05m + 1000 * 0.10m + (AccountBalance - 2000) * 0.15m) / 365;
            
        }
    }
}
