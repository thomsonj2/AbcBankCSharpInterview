using abc_bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank_repository.Interface
{
    public interface IBankRepository
    {
        void AddCustomer(Customer customer);
        List<Customer> GetCustomers();
        decimal GetTotalInterestPaid();
    }
}
