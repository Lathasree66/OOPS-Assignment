using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class BankAccount
    {
        
        public int AccountNumber;
        public List<string> AccountHolderName;
        public string AccountOpeningDate;
        public double BalanceAmount;

        public List<Transaction> ListOfTransactions = new List<Transaction>();
        public class Transaction
        {
            public int TransactionAc { get; set; }
            public string TransactionHolderName { get; set; }
            public DateTime TransactionDate { get; set; }
            public TransactionType TransactionType { get; set; }
            public string Description { get; set; }
            public double TransactionAmount { get; set; }
        }
        public enum TransactionType
        {
            Deposit,
            Withdrawal
        }

         public void ViewTransactions()
        {

            if (ListOfTransactions.Count <= 0)
                Console.WriteLine("There is no transaction yet.");
            else
            {
                if (ListOfTransactions.Count > 5)
                {
                    for(int index=0; index <= ListOfTransactions.Count;index++)
                    {
                        ListOfTransactions.RemoveAt(index);
                        if(ListOfTransactions.Count == 5)
                        {
                            break;
                        } 
                    }
                }
                foreach (var tran in ListOfTransactions)
                {
                    Console.WriteLine("Account " + tran.TransactionAc + " of " + tran.TransactionHolderName + " has " + tran.TransactionType + " " + tran.TransactionAmount + " on " + tran.TransactionDate);
                }
            }
        }
        Transaction transaction = new Transaction();
        public void InsertTransaction(Transaction transaction)
        {
            ListOfTransactions.Add(transaction);
        }
        
        public abstract void Debit(double debitamount);
        public void Credit(double creditamount)
        {
            if (creditamount > 1000.00)
                throw new ArgumentException("Cannot transfer more than 1000.00");
            BalanceAmount = BalanceAmount + creditamount;
            balanceAmount("Deposited", creditamount);
            var transaction = new Transaction()
            {
                TransactionDate = DateTime.Now,
                TransactionType = TransactionType.Deposit,
                TransactionAmount = creditamount,
                TransactionHolderName = AccountHolderName[0],
                TransactionAc = AccountNumber
            };
            InsertTransaction(transaction);
        }

        public double balanceAmount()
        {
            return BalanceAmount;
        }

        public void balanceAmount(string transtype, double amount)
        {
            if(transtype=="Withdrawn")
            {
                Console.WriteLine("Hey " + AccountHolderName[0] + " You Withdrawn "+ amount +" and Remaining Bank Balance is: " + BalanceAmount);
            }
            else
            {
                Console.WriteLine("Hey " + AccountHolderName[0] + " You Deposited " + amount + " and Remaining Bank Balance is: " + BalanceAmount);
            }
        }
    }
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(int acnum, List<string> acholdername, string acopeningdate, double balamount)
        {
                Regex rexObj = new Regex(@"^\d{9}");
                if (rexObj.IsMatch(Convert.ToString(acnum)) == false)
                    throw new ArgumentException("Account Number cannot be less than nine digits.Please Enter Valid Number:");
                AccountNumber = acnum;
                AccountHolderName = acholdername;
                AccountOpeningDate = acopeningdate;
                BalanceAmount = balamount;
        }
        public override void Debit(double debitamount)
        {
            if(debitamount>BalanceAmount)
                throw new ArgumentException("Withdrawl amount cannot be greater than Account Balance");
            if (debitamount > 1000.00)
                throw new ArgumentException("Cannot transfer more than 1000.00");
            BalanceAmount = BalanceAmount - (debitamount + (debitamount * 0.01));
                balanceAmount("Withdrawn", debitamount);
                var transaction = new Transaction()
                {
                    TransactionDate = DateTime.Now,
                    TransactionType = TransactionType.Withdrawal,
                    TransactionAmount = debitamount,
                    TransactionHolderName = AccountHolderName[0],
                    TransactionAc = AccountNumber
                };
                InsertTransaction(transaction);
        }
    }
    public class CheckingAccount : BankAccount 
    {
        public CheckingAccount(int acnum, List<string> acholdername, double balamount)
        {
                Regex rexObj = new Regex(@"^\d{9}");
                if (rexObj.IsMatch(Convert.ToString(acnum)) == false)
                    throw new ArgumentException("Account Number cannot be less than nine digits.Please Enter Valid Number:");
                AccountNumber = acnum;
                AccountHolderName = acholdername;
                AccountOpeningDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 
                BalanceAmount = balamount;
        }
        public override void Debit(double debitamount)
        {
            if (debitamount > BalanceAmount)
                throw new ArgumentException("Withdrawl amount cannot be greater than Account Balance");
            if (debitamount > 1000.00)
                throw new ArgumentException("Cannot transfer more than 1000.00");
            BalanceAmount = BalanceAmount - (debitamount + (debitamount * 0.025));
            balanceAmount("Withdrawn",debitamount);
            var transaction = new Transaction()
            {
                TransactionDate = DateTime.Now,
                TransactionType = TransactionType.Withdrawal,
                TransactionAmount = debitamount,
                TransactionHolderName = AccountHolderName[0],
                TransactionAc = AccountNumber
            };
            InsertTransaction(transaction);

        }
    }

}
