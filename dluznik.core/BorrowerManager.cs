using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using System;

namespace dluznik.core
{
    public class BorrowerManager
    {
        private List<Borrower> Borrowers { get; set; }

        private string FileName { get; set; } = "borrowers.txt";
        private decimal BorrowerAmount { get; set; }


        public BorrowerManager()
        {
            Borrowers = new List<Borrower>();
            
            if (!File.Exists(FileName))
            {
                return;
            }

            var fileLines = File.ReadAllLines(FileName);

            foreach (var line in fileLines)
            {
               var lineItems = line.Split(';');

                if (decimal.TryParse(lineItems[1], out  var amountInDecimal))
                {
                    AddBorrower(lineItems[0], amountInDecimal, false);
                }

                
            }
        }


        public void AddBorrower(string name, decimal amount, bool shouldSaveToFile = true)
        { 
            var borrower = new Borrower
            {
                Name = name,
                Amount = amount
            };

            Borrowers.Add(borrower);
            
            if(shouldSaveToFile)
            {
                File.AppendAllLines(FileName, new List<string> { borrower.ToString()});
            }

        }

         
        public void DeleteBorrower(string name, bool shouldSaveToFile = true)
        {
            foreach (var borrower in Borrowers)
            {
                if (borrower.Name == name)
                {
                    Borrowers.Remove(borrower);
                    break;
                }

            }
            if (shouldSaveToFile)
            {
                var borrowersToSave = new List<string>();

                foreach (var borrower in Borrowers)
                {
                    borrowersToSave.Add(borrower.ToString());
                }

                File.Delete(FileName);
                File.WriteAllLines(FileName, borrowersToSave);
            }

        }

        public void ChangeBorrower(string name, string calculation, decimal amountToDelete, bool shouldSaveToFile = true)
        {
            foreach (var borrower in Borrowers)
            {
                if (borrower.Name == name)
                {
                    BorrowerAmount = borrower.Amount;
                    Borrowers.Remove(borrower);

                    break;
                }

            }

            if(calculation.ToLower() == "d")
            {
                var borrowerToChange = new Borrower
                {
                    Name = name,
                    Amount = BorrowerAmount + amountToDelete
                };

                foreach (var borrower in Borrowers)
                {
                    if (borrower.Name == name)
                    {
                        Borrowers.Add(borrowerToChange);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nie ma takiego dłużnika");
                        break;
                    }

                }

            }
            else
            {
                var borrowerToChange = new Borrower
                {
                    Name = name,
                    Amount = BorrowerAmount - amountToDelete
                };

                if (borrowerToChange.Amount > 0)
                {
                    Borrowers.Add(borrowerToChange);
                }
            }

            if (shouldSaveToFile)
            {
                var borrowersToSave = new List<string>();

                foreach (var borrower in Borrowers)
                {
                    borrowersToSave.Add(borrower.ToString());
                }

                File.Delete(FileName);
                File.WriteAllLines(FileName, borrowersToSave);
            }

        }

        public List<string> ListBorrowers()
        {
            var borrowersStrings = new List<string>();
            var indexer = 1;

            foreach (var borrower in Borrowers)
            {
                var borrowersString = indexer + ". " + borrower.Name + " - " + borrower.Amount + " zł";
                indexer++;

                borrowersStrings.Add(borrowersString);
            }



            return borrowersStrings;


        }

    }
}
