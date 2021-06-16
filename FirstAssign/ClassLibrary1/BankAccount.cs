using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class BankAccount
    {
        public int AccountNumber { get; set; }
        public List<string> AccountHolderName { get; set; }
        public string AccountOpeningDate { get; set; }
        public double BalanceAmount { get; set; }
        public List<string> ListOfTransactions { get; set; }

        public abstract void Debit(int debitamount);
        public void Credit(int creditamount)
        {
            BalanceAmount = BalanceAmount + creditamount;
        }

        public double balanceAmount()
        {
            return BalanceAmount;
        }
    }
    public class SavingsAccount : BankAccount
    {
        public override void Debit(int debitamount)
        {
            BalanceAmount = BalanceAmount - (debitamount+ (debitamount * 0.01));
        }

    }
    public class CheckingAccount : BankAccount
    {
        public override void Debit(int debitamount)
        {
            BalanceAmount = BalanceAmount - (debitamount + (debitamount * 0.025));
        }
    }
}
