using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class BankAccount
    {
        public List<string> ListOfTransactions { get; set; }

        public int AccountNumber;
        public List<string> AccountHolderName;
        public string AccountOpeningDate;
        public double BalanceAmount;
        public abstract void Debit(double debitamount);
        public void Credit(int creditamount)
        {
            BalanceAmount = BalanceAmount + creditamount;
            balanceAmount("Deposited", creditamount);
        }

        public double balanceAmount()
        {
            return BalanceAmount;
        }

        public void balanceAmount(string transactiontype, double amount)
        {
            if(transactiontype=="Withdrawn")
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
            AccountNumber = acnum;
            AccountHolderName = acholdername;
            AccountOpeningDate = acopeningdate;
            BalanceAmount = balamount;
        }
        public override void Debit(double debitamount)
        {
            BalanceAmount = BalanceAmount - (debitamount+ (debitamount * 0.01));
            balanceAmount("Withdrawn", debitamount);
        }

    }
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(int acnum, List<string> acholdername, double balamount)
        {
            AccountNumber = acnum;
            AccountHolderName = acholdername;
            AccountOpeningDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 
            BalanceAmount = balamount;

        }
        public override void Debit(double debitamount)
        {
            BalanceAmount = BalanceAmount - (debitamount + (debitamount * 0.025));
            balanceAmount("Withdrawn",debitamount);
        }
    }
}
