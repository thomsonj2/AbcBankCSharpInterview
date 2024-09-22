using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank
{
    public class Transaction
    {
        public decimal Amount { get; }
        public DateTime TimeStamp { get; }
        public TransactionType Type { get; }

        private DateTime transactionDate;

        public Transaction(decimal amount, TransactionType type, DateTime timeStamp) 
        {
            TimeStamp = timeStamp;
            Amount = amount;
            Type = type;
        }
    }
}
