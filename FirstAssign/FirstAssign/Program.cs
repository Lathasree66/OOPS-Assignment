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
            SavingsAccount savobj = new SavingsAccount(1234, new List<string>() { "Steve", "Hill" }, "16 - 06 - 2021", 10000.00);
            CheckingAccount checkobj = new CheckingAccount(1234, new List<string>() { "Joseph" }, 0.00);
            savobj.Debit(500);
            savobj.Credit(1000);
            checkobj.Credit(6000);
            checkobj.Debit(1000);
            savobj.Credit(5000);

            Console.ReadLine();

        }
    }
}
