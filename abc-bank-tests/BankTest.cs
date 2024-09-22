using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abc_bank;

namespace abc_bank_tests
{
    [TestClass]
    public class BankTest
    {

        private static readonly double DOUBLE_DELTA = 1e-15;

        [TestMethod]
        public void CustomerSummary() 
        {
            Bank bank = new Bank();
            Customer john = new Customer("John");
            Account account = new CheckingAccount();
            john.OpenAccount(account);
            bank.AddCustomer(john);

            Assert.AreEqual("Customer Summary\n - John (1 account)", bank.CustomerSummary());
        }

        [TestMethod]
        public void CheckingAccount() 
        {
            CheckingAccount account = new CheckingAccount();
            account.Deposit(1000);

            decimal expectedInterest = 1000 * 0.001m / 365;
            decimal interest = account.InterestCalculation();

            Assert.AreEqual(expectedInterest, interest);
        }

        [TestMethod]
        public void Savings_account() 
        {
            SavingsAccount account = new SavingsAccount();
            account.Deposit(1500);

            decimal expectedInterest = ((1000 * 0.001m) + (500 * 0.002m)) / 365;
            decimal interest = account.InterestCalculation();

            Assert.AreEqual(expectedInterest, interest);
        }

        [TestMethod]
        public void Maxi_savings_account_No_Withdrawl_In_10_Days() 
        {
            MaxiSavingAccount account = new MaxiSavingAccount();
            account.Deposit(2000);
            account.Deposit(500);

            decimal expectedInterest = ((1000 * 0.05m) + (1000 * 0.10m) + (500 * 0.15m)) / 365;
            decimal interest = account.InterestCalculation();

            Assert.AreEqual(expectedInterest, interest);
        }

        [TestMethod]
        public void Maxi_savings_account_Recent_Withdrawl()
        {
            MaxiSavingAccount account = new MaxiSavingAccount();
            account.Deposit(2000);
            account.Withdraw(100);

            decimal expectedInterest = (1900 * 0.001m / 365);
            decimal interest = account.InterestCalculation();

            Assert.AreEqual(expectedInterest, interest);
        }
    }
}
