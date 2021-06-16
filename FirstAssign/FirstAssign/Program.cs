using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAssign
{
    class Program
    {
        static void Main(string[] args)
        {

            SavingsAccount Savobj = new SavingsAccount();
            Savobj.AccountNumber = 12345;
            Savobj.AccountHolderName = new List<string>() { "Steve","Hill"};
            Savobj.AccountOpeningDate = "15-06-2021";
            Savobj.BalanceAmount = 10000;
            Savobj.Debit(500);
            Console.WriteLine("Hey "+ Savobj.AccountHolderName[0] +" You withdrawn 500 and Bank Balance is: "+Savobj.balanceAmount());
            Savobj.Credit(1000);
            Console.WriteLine("Hey " + Savobj.AccountHolderName[0] + " You deposited 1000 and Remaining Bank Balance is: " + Savobj.balanceAmount());

            CheckingAccount checkobj = new CheckingAccount();
            checkobj.AccountNumber = 54321;
            checkobj.AccountHolderName = new List<string>() {"Joseph"};
            checkobj.AccountOpeningDate = "16-06-2021";
            checkobj.BalanceAmount = 5000;
            checkobj.Credit(6000);
            Console.WriteLine("Hey " + checkobj.AccountHolderName[0] + " You deposited 6000 and Bank Balance is: " + checkobj.balanceAmount());
            checkobj.Debit(1000);
            Console.WriteLine("Hey " + checkobj.AccountHolderName[0] + " You withdrawn 1000 and Bank Balance is: " + checkobj.balanceAmount());

            Savobj.Credit(5000);
            Console.WriteLine("Hey " + Savobj.AccountHolderName[0] + " You deposited 5000 and Remaining Bank Balance is: " + Savobj.balanceAmount());

            Console.ReadLine();

        }
    }
}
