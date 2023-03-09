namespace VendingMachine
{
    public class Controller
    {
        private readonly Inventory _inventory = new();
        private readonly Basket _basket = new(); 

        public Controller() {}

        public void Start()
        {
            while (true)
            {
                _inventory.DisplayInventory();
                var selectedProduct = SelectProduct();

                if (selectedProduct.IsInStock())
                {
                    GetPayment(selectedProduct);
                    _basket.DispenseItem(selectedProduct);
                }
                else
                {
                    Console.WriteLine("SOLD OUT\n");
                }
            }
        }

        private Product SelectProduct()
        {
            Console.WriteLine("\nPlease select an item...\n");

            var intSelection = -1;
            while (intSelection >= _inventory.GetNumberOfProducts() || intSelection < 0)
            {
                try
                {
                    string selection = Console.ReadLine();
                    intSelection += int.Parse(selection);
                }
                catch { }
                finally
                {
                    Console.WriteLine("\nSorry, option not recognized. Please enter a valid number.");
                }
            }

            Product selectedProduct = _inventory.GetProduct(intSelection);
            Console.WriteLine("\nYou have selected " + selectedProduct.Name);

            return selectedProduct; 
        }

        private void GetPayment(Product selectedProduct)
        {
            Console.WriteLine("\nINSERT COIN");

            while (_basket.GetMoney() < selectedProduct.Price)
            {
                Console.WriteLine("\nPRICE " + Money.Format(selectedProduct.Price));
                try
                {
                    string input = Console.ReadLine();
                    if (input == "RESET")
                    {
                        _basket.Clear();
                        break;
                    }
                    decimal moneyInserted = decimal.Parse(input);
                    _basket.InsertMoney(moneyInserted);
                }
                catch
                {
                    Console.WriteLine("\nSorry, money not recognized. Coins accepted: 1p, 2p, 5p, 10p, 20p, 50p, £1, £2");
                }
            }
        }
    }
}
