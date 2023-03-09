namespace VendingMachine
{
    public class Inventory
    {
        private readonly List<Product> Products = new(); 
        public Inventory() 
        {
            AddProduct("cola", 1, 10);
            AddProduct("crisps", 0.5m, 1);
            AddProduct("chocolate", 0.65m, 0);
        }

        public void AddProduct(string name, decimal money, int stock)
        {
            Product p = new(name, money, stock);
            Products.Add(p);
        }

        public List<Product> GetInventory() => Products;
        public Product GetProduct(int option) => Products[option]; 
        public int GetNumberOfProducts() => Products.Count;
        public void DisplayInventory()
        {
            Products.ForEach(p => {
                    var id = Products.IndexOf(p) + 1;
                    Console.WriteLine($"{id} {p.Name} P:{Money.Format(p.Price)} Q:{p.GetStock()}"); 
                });
        }
        
    }
}
