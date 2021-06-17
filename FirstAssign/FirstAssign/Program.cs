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
            SavingsAccount savobj = new SavingsAccount(123456789, new List<string>() { "Steve", "Hill" }, "16 - 06 - 2021", 10000.00);
            savobj.Debit(500.00);
            savobj.Credit(900.00);
            savobj.Credit(1000.00);
            savobj.Debit(1000.00);
            savobj.Debit(800.00);
            savobj.Credit(600.00);
            savobj.ViewTransactions();
            CheckingAccount checkobj = new CheckingAccount(167243568, new List<string>() { "Joseph" }, 0.00);
            checkobj.Credit(1000.00);
            checkobj.Debit(300.00);
            checkobj.ViewTransactions();
            Console.ReadLine();

        }
    }
}
