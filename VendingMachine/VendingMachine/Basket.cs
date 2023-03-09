namespace VendingMachine
{
    public class Basket
    {
        private decimal Amount { get; set; } = 0m; 

        public Basket() { }
        public decimal GetMoney() { return Amount; }

        public void InsertMoney(decimal insertedMoney)
        {
            if (Money.IsValid(insertedMoney))
            {
                Amount += insertedMoney;
                Console.WriteLine("Amount so far: "+Money.Format(Amount));
            }
            else
            {
                Console.WriteLine("\nSorry, money not recognized. Coins accepted: 1p, 2p, 5p, 10p, 20p, 50p, £1, £2");
            }
        }

        public void DispenseItem(Product productDispensed)
        {
            Console.WriteLine("THANK YOU\n");
            productDispensed.Sell();
            ReturnChange(productDispensed.Price);
            Amount = 0m;
        }

        private void ReturnChange(decimal itemPrice)
        {
            var change = Amount - itemPrice; 
            if (change > 0)
            {
                Console.WriteLine($"Please take your change: {Money.Format(change)} \n");
            }
        }

        public void Clear()
        {
            Console.WriteLine($"Money dispensed: {Money.Format(Amount)} \n");
            Amount = 0m;
        }
    }
}
