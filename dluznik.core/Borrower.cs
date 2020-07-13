namespace dluznik.core
{
    class Borrower
    {
        public string Name { get; set; }

        public decimal Amount { get; set; }

        public override string ToString()
        {
            return Name + ";" + Amount.ToString();
        }
    }
}
