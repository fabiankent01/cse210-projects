using System;

public class ShoppingCartUI
{
    private Cart cart;
    public ShoppingCartUI()
    {
        cart = new Cart();
        cart.MakeSaleList();
    }
    public void GetUserInput()
    {
        Console.Clear();
        cart.ShowSpinner();
        Console.Clear();

        int end = -1;
        while (!(end == 6))
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            char star = '\u2605';
            Console.WriteLine($"{star}   Welcome to the Online Shopping cart System  {star}\n");
            Console.Write("1. Display all products available for sale\n2. Add Products to your Cart\n3. View the items in your Cart\n4. Remove Items from your Cart\n" +
            "5. Make a Payment\n6. View past orders\n7. Quit\nPlease Select One of the following: ");
            string user = Console.ReadLine();
            int choice = int.Parse(user);

            if (choice == 1)
            {
                DisplayProducts();
            }

            else if (choice == 2)
            {
                cart.AddToCart();
            }

            else if (choice == 3)
            {
                DisplayCartContent();
                Console.WriteLine("Please click any button to go to the Main Menu: ");
                Console.ReadLine();
                Console.Clear();
            }

            else if (choice == 4)
            {
                DisplayCartContent();
                Console.Write("\nWhat item would you like to remove from your cart : ");
                string item = Console.ReadLine();
                int product = int.Parse(item) - 1;
                cart.RemoveFromCart(product);
            }

            else if (choice == 5)
            {
                DisplayTotalPrice();
            }

            else if (choice == 6)
            {
                Console.WriteLine();
                cart.LoadOrderHistoryFromFile();
            }

            else if (choice == 7)
            {
                break;
            }
        }
    }

    public void DisplayProducts()
    {
        cart.DisplayAll();
        Console.WriteLine("Please click any button to go to the Main Menu: ");
        Console.ReadLine();
        Console.Clear();
    }

    public void DisplayCartContent()
    {
        cart.DisplayCart();

    }

    public void DisplayTotalPrice()
    {
        if (cart.CalculateTotalPrice() == 0)
        {
            Console.WriteLine("YOUR CART IS EMPTY. YOU HAVE NOTHING TO PAY FOR\n");
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"The total price of everything in your Cart is ${cart.CalculateTotalPrice()}\n");

            Console.Write("Insert the amount of money you have to pay: ");
            string money = Console.ReadLine();
            int amount = int.Parse(money);

            if (amount < cart.CalculateTotalPrice())
            {
                Console.WriteLine("PAYMENT UNSUCCESSFUL !!!!\nYOU DON'T HAVE ENOUGH MONEY TO PAY FOR THE ITEMS IN YOUR CART.");
                cart.ShowSpinner();
                Console.Clear();
            }
            else
            {
                decimal change = amount - cart.CalculateTotalPrice();
                Console.WriteLine($"PAYMENT SUCCESSFUL !!!!!\nYOUR CHANGE IS ${change} ");
                cart.SaveOrderHistoryToFile(amount, change);
                Console.WriteLine("\nTHE ITEMS YOU PAID FOR ARE NO LONGER IN YOUR CART.");
                cart.ShowSpinner();
                Console.Clear();
            }
        }
    }


}