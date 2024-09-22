using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank
{
    public class Customer
    {
        private String name;
        private List<Account> accounts;

        public Customer(String name)
        {
            this.name = name;
            this.accounts = new List<Account>();
        }

        public String GetName()
        {
            return name;
        }

        public Customer OpenAccount(Account account)
        {
            accounts.Add(account);
            return this;
        }

        public int GetNumberOfAccounts()
        {
            return accounts.Count;
        }

        public decimal TotalInterestEarned() 
        {
            decimal total = 0;
            foreach (Account a in accounts)
                total += a.InterestCalculation();
            return total;
        }

        public String GetStatement() 
        {
            if(accounts.Count < 1)
            {
                return string.Format("Customer {0} has no accounts", GetName());
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Statement for {0}", GetName()));
            foreach (var account in accounts)
            {
                sb.AppendLine(string.Format("Type: {0}, Balance: {1:F2}", account.getAccountType().ToString(), account.AccountBalance));
                sb.AppendLine("    Transactions:");
                foreach (var transaction in account.Transactions)
                {
                    sb.AppendLine(string.Format("    - Date: {0}, Amount {1:F2}, Type: {2}", transaction.TimeStamp.ToString("yyyy-MM-dd"), transaction.Amount, transaction.Type.ToString()));
                }
            }
            return sb.ToString();
        }

        public List<Account> GetAccounts()
        {
            return accounts;
        }
    }
}
