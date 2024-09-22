using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abc_bank;

namespace abc_bank_tests
{
    [TestClass]
    public class BankTest
    {
        [TestMethod]
        public void CustomerSummaryOneAccount() 
        {
            Bank bank = new Bank();
            Customer john = new Customer("John");
            Account account = new CheckingAccount();
            john.OpenAccount(account);
            bank.AddCustomer(john);

            string acutal = bank.GetCustomerAccountSummary();
            string expected = "Customer: John, Accounts: 1\r\n";
            Assert.AreEqual(expected, acutal);


        }

        [TestMethod]
        public void CustomerSummaryTwoAccounts()
        {
            Bank bank = new Bank();
            Customer john = new Customer("John");
            Account account = new CheckingAccount();
            john.OpenAccount(account);

            Customer larry = new Customer("Larry");
            larry.OpenAccount(new CheckingAccount());
            larry.OpenAccount(new SavingsAccount());

            bank.AddCustomer(john);
            bank.AddCustomer(larry);

            string acutal = bank.GetCustomerAccountSummary();
            string expected = "Customer: John, Accounts: 1\r\nCustomer: Larry, Accounts: 2\r\n";
            Assert.AreEqual(expected, acutal);


        }

        [TestMethod]
        public void TotalInterestCalculation()
        {
            Bank bank = new Bank();
            Customer john = new Customer("John");
            Account johnAccount = new CheckingAccount();
            johnAccount.Deposit(2000);
            john.OpenAccount(johnAccount);

            Customer larry = new Customer("Larry");
            Account larryAccount1 = new SavingsAccount();
            larryAccount1.Deposit(1500);
            larry.OpenAccount(larryAccount1);
            MaxiSavingAccount larryAccount2 = new MaxiSavingAccount();
            larryAccount2.Deposit(3000);
            larry.OpenAccount(larryAccount2);

            bank.AddCustomer(john);
            bank.AddCustomer(larry);

            decimal acutal = bank.totalInterestPaid();
            decimal expected = 0.8328767123287671232876712329M;
            Assert.AreEqual(expected, acutal);


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
