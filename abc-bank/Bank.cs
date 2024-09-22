using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank
{
    public class Bank
    {
        private List<Customer> Customers { get; }

        public Bank()
        {
            Customers = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public string GetCustomerAccountSummary()
        {
            Dictionary<string, int> customerSummary = Customers.ToDictionary(c => c.GetName(), c => c.GetNumberOfAccounts());
            StringBuilder sb = new StringBuilder();
            foreach (var key in customerSummary.Keys)
            {
                sb.AppendLine(string.Format("Customer: {0}, Accounts: {1}", key, customerSummary[key]));
            }
            return sb.ToString();
        }

        public List<Customer> GetCustomerList()
        {
            return Customers;
        }

        public decimal totalInterestPaid() {
            decimal totalInterest = 0;

            foreach (var customer in Customers)
            {
                foreach (var account in customer.GetAccounts())
                {
                    totalInterest += account.InterestCalculation();
                }
            }

            return totalInterest;
        }
    }
}
