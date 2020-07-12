using dluznik.core;
using System;

namespace dluznik
{
    public class DebtorApp
    {
        public BorrowerManager BorrowerManager { get; set; } = new BorrowerManager();

        public void IntrodebtorApp()
        {

        }


        public void AddBorrower()
        {

            Console.WriteLine("Podaj nazwę dłużnika, którego chcesz dodac do listy");

            var userName = Console.ReadLine();

            Console.WriteLine("Podaj kwotę długu");

            var userAmount = Console.ReadLine();

            var amountInDecimal = default(decimal);

            while (!decimal.TryParse(userAmount, out amountInDecimal))
            {
                Console.WriteLine("Podano nieprawidłową kwotę");

                Console.WriteLine("Podaj kwotę długu");

                userAmount = Console.ReadLine();
            }

            BorrowerManager.AddBorrower(userName, amountInDecimal);            
        }


        public void DeleteBorrower()
        {
            
        }


        public void ListAllBorrowers()
        {
            
        }


        public void AskForAction()
        {

        }

            
    }
}
