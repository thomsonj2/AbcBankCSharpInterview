using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using abc_bank;
using System.Text;

namespace abc_bank_tests
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void TestApp()
        {
            Account checkingAccount = new CheckingAccount();
            Account savingsAccount = new SavingsAccount();

            Customer henry = new Customer("Henry").OpenAccount(checkingAccount).OpenAccount(savingsAccount);

            checkingAccount.Deposit((decimal)100.0m);
            savingsAccount.Deposit((decimal)4000.0m);
            savingsAccount.Withdraw((decimal)200.0m);
            DateTime currentDate = DateProvider.getInstance().Now();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Statement for Henry"));
            sb.AppendLine(string.Format("Type: Checking, Balance: 100.00"));
            sb.AppendLine("    Transactions:");
            sb.AppendLine(string.Format("    - Date: {0}, Amount 100.00, Type: Deposit", currentDate.ToString("yyyy-MM-dd")));
            sb.AppendLine(string.Format("Type: Savings, Balance: 3800.00"));
            sb.AppendLine("    Transactions:");
            sb.AppendLine(string.Format("    - Date: {0}, Amount 4000.00, Type: Deposit", currentDate.ToString("yyyy-MM-dd")));
            sb.AppendLine(string.Format("    - Date: {0}, Amount 200.00, Type: Withdrawal", currentDate.ToString("yyyy-MM-dd")));
            string expected = sb.ToString();
            string actual = henry.GetStatement();

            Assert.AreEqual(expected, actual);
        
        }

        [TestMethod]
        public void TestNoAccount()
        {

            Customer henry = new Customer("Henry");

            string expected = "Customer Henry has no accounts";
            string actual = henry.GetStatement();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestOneAccount()
        {
            Customer oscar = new Customer("Oscar").OpenAccount(new SavingsAccount());
            Assert.AreEqual(1, oscar.GetNumberOfAccounts());
        }

        [TestMethod]
        public void TestTwoAccount()
        {
            Customer oscar = new Customer("Oscar")
                 .OpenAccount(new SavingsAccount());
            oscar.OpenAccount(new CheckingAccount());
            Assert.AreEqual(2, oscar.GetNumberOfAccounts());
        }

        [TestMethod]
        public void TestThreeAccounts()
        {
            Customer oscar = new Customer("Oscar")
                    .OpenAccount(new SavingsAccount());
            oscar.OpenAccount(new CheckingAccount());
            oscar.OpenAccount(new MaxiSavingAccount());
            Assert.AreEqual(3, oscar.GetNumberOfAccounts());
        }
    }
}
