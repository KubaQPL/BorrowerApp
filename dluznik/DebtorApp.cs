using dluznik.core;
using System;
using System.IO;

namespace dluznik
{
    public class DebtorApp
    {
        public BorrowerManager BorrowerManager { get; set; } = new BorrowerManager();

        public void IntrodebtorApp()
        {
            Console.WriteLine("Hej, witam w aplikacji Dłużnik. Zapisujemy tutaj listę dłużników, tak abyś wiedział kto ile pieniędzy jest Ci winien!");
            Console.WriteLine();
        }


        public void AddBorrower()
        {
            Console.Clear();
            Console.WriteLine("Podaj nazwę dłużnika, którego chcesz dodac do listy");

            var userName = Console.ReadLine();
            Console.WriteLine();
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
            Console.Clear();
        }


        public void DeleteBorrower()
        {
            Console.Clear();
            Console.WriteLine("Podaj nazwę dłużnika, którego chcesz usunąć z listy");

            var userName = Console.ReadLine();

            BorrowerManager.DeleteBorrower(userName);

            Console.ReadLine();
            Console.Clear();
        }

        public void ChangeBorrower()
        {
            Console.Clear();
            Console.WriteLine("Podaj nazwę dłużnika, któremu chcesz zmienić kwotę długu");

            var userName = Console.ReadLine();
            Console.WriteLine("Chcesz odjąć czy dodać kwotę do długu? [D/O]");
            var calculation = Console.ReadLine();

            if(calculation.ToLower() == "d")
            {
                Console.WriteLine("Podaj kwotę do dodania");
            }
            else if(calculation.ToLower() == "o") 
            {
                Console.WriteLine("Podaj kwotę do odjęcia");
            } 
            else
            {
                Console.WriteLine("Podano nieprawidłową wartość, wybierz: D lub O");
            }

            var amountToDelete = Console.ReadLine();

            BorrowerManager.ChangeBorrower(userName, calculation, decimal.Parse(amountToDelete));

            Console.ReadLine();
            Console.Clear();
        }


        public void ListAllBorrowers()
        {
            Console.Clear();
            if (File.Exists("borrowers.txt"))
            {
                var content = File.ReadAllText("borrowers.txt");
                if(content.Length <= 0)
                {
                    Console.WriteLine("Nie posiadasz dłużników");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Oto lista Twoich dłużnmików:");

                    foreach (var borrower in BorrowerManager.ListBorrowers())
                    {
                        Console.WriteLine(borrower);
                    }
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Nie posiadasz dłużników");
                Console.ReadLine();
            }
            Console.Clear();
        }


        public void AskForAction()
        {
            Console.WriteLine("Podaj czynność, którą chcesz wykonać");

            var userInput = default(string);

            while (userInput != "exit")
            {
                Console.WriteLine("add - Dodawanie dłużnika");
                Console.WriteLine("del - usuwanie dłużnika");
                Console.WriteLine("calc - Dodaj/odejmij kwotę od długu?");
                Console.WriteLine("list - Wypisanie listy dłużników");
                Console.WriteLine("exit - Wyjście z programu");

                userInput = Console.ReadLine();
                userInput = userInput.ToLower();

                switch (userInput)
                {
                    case "add":
                        AddBorrower();
                        break;
                    case "del":
                        DeleteBorrower();
                        break;
                    case "calc":
                        ChangeBorrower();
                        break;
                    case "list":
                        ListAllBorrowers();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("podaną złą wartość");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                }
            }

        }
            
    }
}
