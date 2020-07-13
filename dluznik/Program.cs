using System;

namespace dluznik
{
    class Program
    {
        static void Main(string[] args)
        {
            var debtorApp = new DebtorApp();
            debtorApp.IntrodebtorApp();
            debtorApp.AskForAction();
        }
    }
}
