using System;
using System.Collections.Generic;
using System.IO;

public class Cart
{
    private List<Product> _products;
    private decimal _totalPrice;
    private List<Product> _orderedProducts;

    public Cart()
    {
        _totalPrice = 0;
        _products = new List<Product>();
        _orderedProducts = new List<Product>();
    }

    public void ShowSpinner()
    {
        List<string> animatedStrings = new List<string>();
        animatedStrings.Add("|");
        animatedStrings.Add("/");
        animatedStrings.Add("_");
        animatedStrings.Add("\\");
        animatedStrings.Add("|");
        animatedStrings.Add("/");
        animatedStrings.Add("_");
        animatedStrings.Add("\\");

        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(2);
        do
        {
            DateTime CurrentTime = DateTime.Now;
            foreach (string i in animatedStrings)
            {
                if (CurrentTime < end)
                {
                    Console.Write(i);
                    Thread.Sleep(100);
                    Console.Write("\b \b");
                }
            }
        } while (DateTime.Now < end);
    }

    public void MakeSaleList()
    {
        // Create a random number generator
        Random random = new Random();
        // Define a date range (start and end dates)
        DateTime startDate = new DateTime(2000, 1, 1);
        DateTime endDate = new DateTime(2023, 12, 31);
        // Generate a random number of days between the start and end dates
        int range = (endDate - startDate).Days;
        // Generate a random number of days to add to the start date
        int randomDays = random.Next(range);
        // Add the random number of days to the start date to get a random date
        DateTime randomDate = startDate.AddDays(randomDays);
        string date = randomDate.ToLongDateString();

        _products.Add(new ElectronicProduct("Laptop", "high-performance laptop", 800, "Electronic", 8, 6, "Hewlett Packard"));
        _products.Add(new ElectronicProduct("Smartphone", "Latest model smartphone", 500, "Electronic", 10, 5, "Apple"));
        _products.Add(new ElectronicProduct("Smart TV", "4K Smart TV", 700, "Electronic", 3, 10, "SAMSUNG"));
        _products.Add(new ElectronicProduct("Headphones", "Wireless noise-canceling headphones", 100, "Electronic", 12, 2, "JBL"));
        _products.Add(new ElectronicProduct("Gaming Console", "Next-gen gaming console", 300, "Electronic", 13, 4, "X-BOX"));

        _products.Add(new ClothingProduct("T-Shirt", 20, "Plain cotton T-shirt", "Clothing", 20, "Large (L)", "Red", "Silk"));
        _products.Add(new ClothingProduct("Jeans", 40, "Men's blue jeans", "Clothing", 7, "Medium (M)", "Black", "Denim"));
        _products.Add(new ClothingProduct("Women's Gown", 50, "Women's evening dress", "Clothing", 3, "Small (S)", "White", "Chiffon"));
        _products.Add(new ClothingProduct("Sneakers", 60, "Running sneakers", "Clothing", 6, "38", "Blue", "Cotton"));
        _products.Add(new ClothingProduct("Winter Coat", 80, "Warm winter coat", "Clothing", 3, "Extra Large (XL)", "Green", "Wool"));

        _products.Add(new FoodProduct("Apples (1 lb)", (decimal)1.99, "Fresh, organic apples", "Food", 20, date));
        _products.Add(new FoodProduct("Pasta (2 lbs)", (decimal)2.49, "Italian pasta", "Food", 34, date));
        _products.Add(new FoodProduct("Chicken Breasts (2 lbs)", (decimal)7.99, "Boneless chicken breasts", "Food", 12, date));
        _products.Add(new FoodProduct("Rice (5 lbs)", (decimal)4.99, "Long-grain white rice", "Food", 3, date));
        _products.Add(new FoodProduct("Milk (1 gallon)", (decimal)2.49, "Fresh whole milk", "Food", 20, date));

        _products.Add(new FurnitureProduct("Sofa", 799, "Modern fabric sofa", "Furniture", 3, "Fabric"));
        _products.Add(new FurnitureProduct("Dining Table", 499, "Wooden dining table with chairs", "Furniture", 2, "Wood and Glass"));
        _products.Add(new FurnitureProduct("Bed Frame", 299, "Queen-size bed frame", "Furniture", 5, "Wood"));
        _products.Add(new FurnitureProduct("Bookshelf", 149, "Tall bookshelf with adjustable shelves", "Furniture", 12, "Wood"));
        _products.Add(new FurnitureProduct("Coffee Table", 99, "Glass-top coffee table", "Furniture", 11, "Glass and Metal"));

        _products.Add(new ToyProduct("LEGO Set", (decimal)39.99, "Large LEGO creative set", "Toy", 20, "5-15 Years"));
        _products.Add(new ToyProduct("Remote Control Car", (decimal)29.99, "Off-road RC car", "Toy", 10, "8-12 Years"));
        _products.Add(new ToyProduct("Barbie Doll", (decimal)19.99, "Fashion doll with accessories", "Toy", 13, "3-12 Years"));
        _products.Add(new ToyProduct("Board Game", (decimal)24.99, "Strategy board game", "Toy", 25, "7+ Years"));
        _products.Add(new ToyProduct("Action Figure", (decimal)9.99, "Superhero action figure", "Toy", 22, "5-16"));
    }

    public void AddToCart()
    {
        // DisplayAll();
        Console.Clear();
        Console.WriteLine("Select the product type to add to the cart:");
        Console.Write("1. Electronic Product\n2. Clothing Product\n3. Food Product\n4. Toy Product\n5. Furniture Product\n");
        Console.Write("Enter your choice (1-4): ");
        int choice = int.Parse(Console.ReadLine());

        List<Product> selectedProducts = new List<Product>();

        switch (choice)
        {
            case 1:
                selectedProducts = _products.Where(product => product is ElectronicProduct).ToList();
                break;
            case 2:
                selectedProducts = _products.Where(product => product is ClothingProduct).ToList();
                break;
            case 3:
                selectedProducts = _products.Where(product => product is FoodProduct).ToList();
                break;
            case 4:
                selectedProducts = _products.Where(product => product is ToyProduct).ToList();
                break;
            case 5:
                selectedProducts = _products.Where(product => product is FurnitureProduct).ToList();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        if (selectedProducts.Count == 0)
        {
            Console.WriteLine("No products of the selected type available.");
            return;
        }
        else
        {
            Console.Clear();
            DisplayProducts(selectedProducts);
        }

        Console.Write("Input the 'SERIAL NUMBER' of the item you want to add to your cart: ");
        string pick = Console.ReadLine();
        int productIndex = int.Parse(pick) - 1;

        if (productIndex >= 0 && productIndex < selectedProducts.Count)
        {
            Product selectedProduct = selectedProducts[productIndex];
            if (selectedProduct.GetQuantity() <= 0)
            {
                Console.WriteLine("PRODUCT OUT OF STOCK. TRY AGAIN SOME TIME");
                ShowSpinner();
            }
            else if (selectedProduct.GetQuantity() > 0)
            {
                Console.Write($"How much of this product do you want: ");
                string amount = Console.ReadLine();
                int quantity = int.Parse(amount);

                if (quantity > 0 && quantity <= selectedProduct.GetQuantity())
                {
                    if (_orderedProducts.Contains(selectedProduct))
                    {
                        int index = _orderedProducts.IndexOf(selectedProduct);
                        Product currentOrderedProduct = _orderedProducts[index];
                        currentOrderedProduct.SetQuantityBought(currentOrderedProduct.GetQuantityBought() + quantity);
                        Console.WriteLine($"----- {selectedProduct.GetName().ToUpper()} x ({quantity}) has been added to your cart  ------");
                        int newQuantity = selectedProduct.GetQuantity() - quantity;
                        selectedProduct.SetQuantity(newQuantity);
                        ShowSpinner();
                        Console.Clear();
                    }
                    else
                    {
                        selectedProduct.SetQuantityBought(quantity);
                        _orderedProducts.Add(selectedProduct);
                        Console.WriteLine($"----- {selectedProduct.GetName().ToUpper()} x ({quantity}) has been added to your cart  ------");
                        int newQuantity = selectedProduct.GetQuantity() - quantity;
                        selectedProduct.SetQuantity(newQuantity);
                        ShowSpinner();
                        Console.Clear();
                    }

                }
                else
                {
                    Console.WriteLine("Sorry, the quantity of your order cannot be more than what we've got !!!");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid 'SERIAL NUMBER'. Please try again.");
        }
    }

    public void RemoveFromCart(int item)
    {
        if (_orderedProducts.Count < item)
        {
            Console.WriteLine("Invalid 'PRODUCT'. Please try again.");
        }
        else
        {
            Product selectedProduct = _orderedProducts[item];
            Console.Write($"Hit '1' to reduce the quantity of {selectedProduct.GetName().ToUpper()}(S) in your cart." +
            $"\nHit '2' to clear your cart of every {selectedProduct.GetName().ToUpper()}\nEnter a choice: ");
            string user = Console.ReadLine();

            if (user == "1")
            {
                Console.Write("\nWhat is the quantity of ordered products you'd like to remove : ");
                string userInput = Console.ReadLine();
                int quantity = int.Parse(userInput);
                UpdateCart(selectedProduct, quantity);
                Console.WriteLine($"------ {quantity} {selectedProduct.GetName().ToUpper()} has been removed from your Cart ------");
                ShowSpinner();
                Console.Clear();
            }
            else if (user == "2")
            {
                _orderedProducts.RemoveAt(item);
                Console.WriteLine($"------ {selectedProduct.GetName().ToUpper()} has been removed from your Cart ------");
                ShowSpinner();
                Console.Clear();
            }
        }
    }

    public void UpdateCart(Product product, int quantity)
    {
        int newProductQuantity = product.GetQuantityBought() - quantity;
        product.SetQuantityBought(newProductQuantity);
    }

    public decimal CalculateTotalPrice()
    {
        _totalPrice = 0;
        foreach (Product p in _orderedProducts)
        {
            decimal actualPrice = p.GetQuantityBought() * p.GetPrice();
            _totalPrice += actualPrice;
        }
        return _totalPrice;
    }

    public void SaveOrderHistoryToFile(int amountPaid, decimal changeGiven)
    {
        DateTime dt = DateTime.Now;
        string currentDate = dt.ToLongDateString();
        string currentTime = dt.ToLongTimeString();

        string fileContent = "";

        foreach (Product product in _orderedProducts)
        {
            fileContent += $"DATE  OF ORDER: {currentDate} || TIME OF ORDER: {currentTime}";
            fileContent += $"\nPRODUCT ORDERED : {product.GetName()} || PRODUCT RATE: ${product.GetPrice()} || QUANTITY BOUGHT: {product.GetQuantityBought()}";
            fileContent += $"\nTOTAL PAID FOR: ${CalculateTotalPrice()} || AMOUNT PAID: ${amountPaid} || CHANGE RETURNED: ${changeGiven}\n\n";
        }
        File.AppendAllText("Orders.txt", fileContent);
        _orderedProducts.Clear();
    }

    public void LoadOrderHistoryFromFile()
    {
    
        try
        {
            string[] lines = System.IO.File.ReadAllLines("Orders.txt");
            Console.Clear();
            ShowSpinner();
            foreach (string p in lines)
            {
                if (lines.Length == 0)
                {
                    Console.WriteLine("YOU HAVE NO PREVIOUS ORDERS. GO ON AND SHOP!!!!!");
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine(p);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("YOU HAVE NO PREVIOUS ORDERS. GO ON AND SHOP!!!!!");
        }
        Console.WriteLine("Please click any button to go to the Main Menu: ");
        Console.ReadLine();
        Console.Clear();
    }

    public void DisplayAll()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        char star = '\u2605';
        for (int i = 0; i < _products.Count; i++)
        {
            _products[i].SetQuantityBought(_products[i].GetQuantity());
            Console.WriteLine($"{star}   " + _products[i].GetProductInfo());
        }
    }

    public void DisplayCart()
    {
        if (_orderedProducts.Count <= 0)
        {
            Console.WriteLine("There is nothing in your cart. GO SHOPPING to add items to your cart !!!!");
            ShowSpinner();
            Console.Clear();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("\nThe Items in your Shopping Cart are:");
            for (int i = 0; i < _orderedProducts.Count; i++)
            {
                Console.WriteLine($"({i + 1}). " + _orderedProducts[i].GetProductInfo());
            }
        }

    }

    public static void DisplayProducts(List<Product> products)
    {
        Console.WriteLine("Available Products:");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"Serial Number: {i + 1}");
            Console.WriteLine(products[i].ShowAvailableProducts());
        }
    }
}