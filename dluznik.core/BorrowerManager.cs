using System.Collections.Generic;
using System.ComponentModel;

namespace dluznik.core
{
    public class BorrowerManager
    {
        private List<Borrower> Borrowers { get; set; }

        public void AddBorrower(string name, decimal amount)
        {
            var borrower = new Borrower
            {
                Name = name,
                Amount = amount
            };

            Borrowers.Add(borrower);

        }


        public void DeleteBorrower(string name)
        {
            foreach (var borrower in Borrowers)
            {
                if (borrower.Name == name)
                {
                    Borrowers.Remove(borrower);
                    return;
                }

            }

        }

        public List<string> ListBorrowers()
        {
            var borrowersStrings = new List<string>();
            var indexer = 1;

            foreach (var borrower in Borrowers)
            {
                var borrowersString = indexer = ". " + borrower.Name + " - " + borrower.Amount + " zł";
                indexer++;

                borrowersStrings.Add(borrowersString);
            }



            return borrowersStrings;


        }

    }
}
