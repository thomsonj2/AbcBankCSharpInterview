using abc_bank;
using abc_bank_repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank_repository
{
    //not implemented for simplicity...  In memory only.  
    public class BankRepository : IBankRepository
    {
        private readonly Bank _bank;

        public BankRepository()
        {
            _bank = new Bank();
        }

        public void AddCustomer(Customer customer)
        {
            _bank.AddCustomer(customer);
        }

        public List<Customer> GetCustomers()
        {
            return _bank.GetCustomerList();
        }

        public decimal GetTotalInterestPaid()
        {
            return _bank.totalInterestPaid();
        }
    }
}
