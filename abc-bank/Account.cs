using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank
{
    public abstract class Account
    {
        public Guid AccountGuid { get; }
        public List<Transaction> Transactions { get; }
        public decimal AccountBalance { get; protected set; }

        public Account() 
        {
            AccountGuid = Guid.NewGuid();
            Transactions = new List<Transaction>();
        }

        public void Deposit(decimal amount) 
        {
            if (amount <= 0) {
                throw new ArgumentException("Deposit amount must be greater than zero");
            } else {
                Transactions.Add(new Transaction(amount, TransactionType.Deposit, DateProvider.getInstance().Now()));
            }
        }

        public void Withdraw(decimal amount) 
        {
            if (amount <= 0) {
                throw new ArgumentException("Withdraw amount must be greater than zero");
            } else {
                Transactions.Add(new Transaction(amount, TransactionType.Withdrawal, DateProvider.getInstance().Now()));
            }
        }

        public abstract decimal InterestCalculation();
        public abstract AccountType getAccountType();
        //TODO: move logic to concrete classes
        //    public double InterestEarned() 
        //    {
        //        double amount = sumTransactions();
        //        switch(accountType){
        //            case SAVINGS:
        //                if (amount <= 1000)
        //                    return amount * 0.001;
        //                else
        //                    return 1 + (amount-1000) * 0.002;
        ////            case SUPER_SAVINGS:
        ////                if (amount <= 4000)
        ////                    return 20;
        //            case MAXI_SAVINGS:
        //                if (amount <= 1000)
        //                    return amount * 0.02;
        //                if (amount <= 2000)
        //                    return 20 + (amount-1000) * 0.05;
        //                return 70 + (amount-2000) * 0.1;
        //            default:
        //                return amount * 0.001;
        //        }
        //    }


        public double sumTransactions()
        {
            throw new NotImplementedException();
           
        }


        //private double CheckIfTransactionsExist(bool checkAll) 
        //{
        //    double amount = 0.0;
        //    foreach (Transaction t in transactions)
        //        amount += t.amount;
        //    return amount;
        //}

        //TODO: implement in concrete classes.  
        //public int GetAccountType()
        //{
        //    return accountType;
        //}
    }
}
