using System;
using System.Security.AccessControl;

class Program
{
    static string currentFilePath;
    static List<Item> catelog = new List<Item>();
    static List<Item> cart = new List<Item>();
    static string userIn = "null";

    static void Main(string[] args)
    {
        // userIn = "0";
        while (userIn == "null")
        {
            Console.Clear();
            System.Console.Write("[1] Catelog\n[2] Checkout\n[3] Exit\nWhich mode would you like to run: ");
            userIn = System.Console.ReadLine();
        
            if (userIn == "1")
            {
                CatelogMainMenu();
                userIn = "null";
            }
            else if (userIn == "2")
            {
                CartMenu();
            }

            if (userIn != "3")
            {
                userIn = "null"; // keeps loop running
            }
        }
    }

    // Catelog menu functions
    static void CatelogMainMenu()
    {
        userIn = "null";

        while (userIn == "null")
        {
            Console.Clear();
            System.Console.Write("[1] Load Catelog from file\n[2] Add Item to Catelog\n[3] Modify Item in Catelog\n[4] Save Catelog\n[5] Exit\nWhat would you like to do? ");
            userIn = System.Console.ReadLine();
            if (userIn == "1")
            {
                LoadCatelog();
            }
            else if (userIn == "2")
            {
                AddToCatelogMenu();
                userIn = "null";
            }
            else if (userIn == "3")
            {
                ModifyCatelogMenu();
                userIn = "null";
            }
            else if (userIn == "4")
            {
                SaveCatelog();
            }

            if (userIn == "5")
            {
                userIn = "3"; // exit code outside the loop
            }
            else
            {
                userIn = "null"; // keeps loop running
            }
        }

        userIn = "null"; // sets userIn so that outer loop can continue to run
    }

    static void LoadCatelog()
    {
        while (true) {
            System.Console.Write("Paste full file path or press ENTER if selected by mistake: ");
            currentFilePath = System.Console.ReadLine();
            
            if (File.Exists(currentFilePath))
            {
                break;
            }
            else
            {
                System.Console.Write("Filepath doesn't lead to a valid file, Exit? [Y/N]");
                String exit = System.Console.ReadLine();
                if (exit.ToUpper() == "y")
                {
                    return; // in the case the user wishes to cancel their selection
                }
            }
        }
        System.Console.Clear();
        
        Array raw = File.ReadAllLines(currentFilePath);
        List<String> semi = [];
        foreach (String line in raw)
        {
            semi.Add(line);
        }
        
        catelog = new List<Item>(); // resets goalList to avoid combining lists
        int corrupt = 0;
        for (int i = 0; i < semi.Count(); i++)
        {
            if (semi[i][0] == '1')
            {
                try
                {
                    Food food = new Food(semi[i]);
                    catelog.Add(food);
                }
                catch
                {
                    System.Console.WriteLine($"{i} [Food] failed at file line {i}");
                    corrupt++;
                }
            }
            else if (semi[i][0] == '2')
            {
                try
                {
                    Produce produce = new Produce(semi[i]);
                    catelog.Add(produce);
                }
                catch
                {
                    System.Console.WriteLine($"{i} [Produce] failed at file line {i}");
                    corrupt++;
                }
            }
            else if (semi[i][0] == '3')
            {
                try
                {
                    Clothing clothing = new Clothing(semi[i]);
                    catelog.Add(clothing);
                }
                catch
                {
                    System.Console.WriteLine($"[Clothing] failed at file line {i}");
                    corrupt++;
                }
            }
            else if (semi[i][0] == '4')
            {
                try
                {
                    Electronic electronic = new Electronic(semi[i]);
                    catelog.Add(electronic);
                }
                catch
                {
                    System.Console.WriteLine($"[Electronic] failed at file line {i}");
                    corrupt++;
                }
            }
            else if (semi[i][0] == '5')
            {
                try
                {
                    Furniture furniture = new Furniture(semi[i]);
                    catelog.Add(furniture);
                }
                catch
                {
                    System.Console.WriteLine($"[Furniture] failed at file line {i}");
                    corrupt++;
                }
            }
            else if (semi[i][0] == '6')
            {
                try
                {
                    Giftcard giftcard = new Giftcard(semi[i]);
                    catelog.Add(giftcard);
                }
                catch
                {
                    System.Console.WriteLine($"[Giftcard] failed at file line {i}");
                    corrupt++;
                }
            }
            else
            {
                corrupt++;
            }
        }
        if (0 < corrupt) {
            System.Console.Write($"{corrupt} Items could not be loaded properly. Press ENTER to continue.");
        }
        else 
        {
            System.Console.Write("Loaded! Press ENTER to continue. ");
        }
        System.Console.ReadLine();
    }

    static void SaveCatelog()
    {
        if (currentFilePath == "NONE")
        {
            System.Console.Write("Name your Goal List: ");
            String title = System.Console.ReadLine();
            File.Create(Path.GetFullPath($"lists\\{title}.txt").Replace("bin\\Debug\\net8.0","")); // for some reason it doesn't like to just do relative paths, removing the "bin\Debug\net8.0" fixes this
        }
        else
        {
            List<String> itemStrings = [];
            foreach (Item i in catelog)
            {
                itemStrings.Add(i.GetRep());
            }
            File.WriteAllLines(currentFilePath, itemStrings);
        }
        System.Console.Write("Catelog saved! Press ENTER to continue. ");
        System.Console.ReadLine();
    }

    // Modify Catelog menu functions
    static void ModifyCatelogMenu()
    {
        userIn = "null";

        while (userIn == "null")
        {
            int index;

            Console.Clear();
            System.Console.Write("[1] Edit Name\n[2] Edit Price\n[3] Change return policy\n[4] RECALL\n[5] Display Attributes\n[6] Remove Item\n[7] Exit\nWhat would you like to do? ");
            userIn = System.Console.ReadLine();
            if (userIn == "1")
            {
                System.Console.Write($"{DisplayCatelog()}What is the index of the item you wish to edit the name of? ");
                try
                {
                    index = Convert.ToInt32(System.Console.ReadLine());

                    System.Console.Write("What is the new item name? ");
                    catelog[index].SetName(System.Console.ReadLine());
                }
                catch
                {
                    System.Console.Write("No item at that index, exiting return policy edit. Press ENTER to continue, then select option 3 and try again.");
                    System.Console.ReadLine();
                }
            }
            else if (userIn == "2")
            {
                System.Console.Write($"{DisplayCatelog()}What is the index of the item you wish to edit the price of? ");
                try
                {
                    index = Convert.ToInt32(System.Console.ReadLine());
                    System.Console.Write("What is the new price? ");
                    try
                    {
                        catelog[index].SetPrice(Convert.ToInt32(System.Console.ReadLine()));
                    }
                    catch
                    {
                        System.Console.Write("Input must be numeric, exiting price edit. Press ENTER to continue, then select option 2 and try again.");
                        System.Console.ReadLine();
                    }
                }
                catch
                {
                    System.Console.Write("No item at that index, exiting price edit. Press ENTER to continue, then select option 2 and try again.");
                    System.Console.ReadLine();
                }
            }
            else if (userIn == "3")
            {
                System.Console.Write($"{DisplayCatelog()}What is the index of the item you wish to toggle the return policy of? ");
                try
                {
                    index = Convert.ToInt32(System.Console.ReadLine());
                    catelog[index].SetCanReturn();
                }
                catch
                {
                    System.Console.Write("No item at that index, exiting return policy edit. Press ENTER to continue, then select option 3 and try again.");
                    System.Console.ReadLine();
                }
            }
            else if (userIn == "4")
            {
                System.Console.Write($"{DisplayCatelog()}What is the index of the item you wish to toggle the recall policy of? ");
                try
                {
                    index = Convert.ToInt32(System.Console.ReadLine());
                    catelog[index].SetRecall();
                }
                catch
                {
                    System.Console.Write("No item at that index, exiting recall policy edit. Press ENTER to continue, then select option 4 and try again.");
                    System.Console.ReadLine();
                }
            }
            else if (userIn == "5")
            {
                System.Console.Write($"{DisplayCatelog()}What is the index of the item you wish to Display? ");
                try
                {
                    index = Convert.ToInt32(System.Console.ReadLine());
                    catelog[index - 1].Display();
                }
                catch
                {
                    System.Console.Write("No item at that index, exiting Display. Press ENTER to continue, then select option 5 and try again.");
                    System.Console.ReadLine();
                }
                
            }
            else if (userIn == "6")
            {
                System.Console.Write($"{DisplayCatelog()}What is the index of the item you wish to remove from sale? ");
                try
                {
                    index = Convert.ToInt32(System.Console.ReadLine());
                    catelog.Remove(catelog[index - 1]);
                }
                catch
                {
                    System.Console.Write("No item at that index, exiting removal. Press ENTER to continue, then select option 6 and try again.");
                    System.Console.ReadLine();
                }
                
            }

            if (userIn != "6")
            {
                userIn = "3"; // exit code outside the loop
            }
            else
            {
                userIn = "null"; // keeps loop running
            }
        }

        userIn = "null"; // sets userIn so that outer loop can continue to run
    }
    static void AddToCatelogMenu()
    {
        userIn = "null";

        while (userIn == "null")
        {
            List<string> atts = [];
            string rawInput = "";

            Console.Clear();
            System.Console.Write("[1] Food\n[2] Produce\n[3] Clothing\n[4] Electronic\n[5] Furniture\n[6] Giftcard\n[7] Exit\nWhat type of item would you like to add? ");
            userIn = System.Console.ReadLine();

            System.Console.Clear();
            if (userIn == "1")
            {
                System.Console.Write("What is the item name? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("What is the item price? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("Is the item returnable? [T/F] ");
                rawInput = System.Console.ReadLine();
                if (rawInput.ToLower() == "f")
                {
                    atts.Add("false");
                }
                else
                {
                    atts.Add("true"); // if user put something else in, default to returnable
                }
                System.Console.Write("What is the expiration date? [MM/dd/YYYY] ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("Any instructions for how to keep (Refrigerated, Frozen, etc.; 'N/A' if none)? [Keep <input>] ");
                atts.Add(System.Console.ReadLine());
                
                try
                {

                    Food food = new Food(atts[0],Convert.ToDouble(atts[1]),Convert.ToBoolean(atts[2]),atts[3],atts[4]);
                    catelog.Add(food);
                }
                catch
                {
                    System.Console.Write("Could not construct Food item properly, try again. Press ENTER to continue. ");
                    System.Console.ReadLine();
                }
            }
            else if (userIn == "2")
            {
                System.Console.Write("What is the item name? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("What is the price per pound? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("Is the item returnable? [T/F] ");
                rawInput = System.Console.ReadLine();
                if (rawInput.ToLower() == "f")
                {
                    atts.Add("false");
                }
                else
                {
                    atts.Add("true"); // if user put something else in, default to returnable
                }
                System.Console.Write("What is the expiration date? [MM/dd/YYYY] ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("Any instructions for how to keep (Refrigerated, Frozen, etc.; 'N/A' if none)? [Keep <input>] ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("What is the greatest expected weight in lbs? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("What is the lowest expected weight in lbs? ");
                atts.Add(System.Console.ReadLine());
                

                try
                {
                    Produce produce = new Produce(atts[0],Convert.ToDouble(atts[1]),Convert.ToBoolean(atts[2]),atts[3],atts[4],Convert.ToDouble(atts[5]),Convert.ToDouble(atts[6]));
                    catelog.Add(produce);
                }
                catch
                {
                    System.Console.Write("Could not construct Produce item properly, try again. Press ENTER to continue. ");
                    System.Console.ReadLine();

                }
            }
            else if (userIn == "3")
            {
                List<string> sizeNames = [];

                System.Console.Write("What is the item name? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("What is the item price? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("Is the item returnable? [T/F] ");
                rawInput = System.Console.ReadLine();
                if (rawInput.ToLower() == "f")
                {
                    atts.Add("false");
                }
                else
                {
                    atts.Add("true"); // if user put something else in, default to returnable
                }
                System.Console.Write("How many sizes are there? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("What is the percent that should be added each time the size is increased? ");
                atts.Add(System.Console.ReadLine());
                
                try
                {
                    Clothing clothing = new Clothing(atts[0],Convert.ToDouble(atts[1]),Convert.ToBoolean(atts[2]),Convert.ToInt32(atts[3]),Convert.ToDouble(atts[4]));
                    catelog.Add(clothing);
                }
                catch
                {
                    System.Console.Write("Could not construct Clothing item properly, try again. Press ENTER to continue. ");
                    System.Console.ReadLine();
                }
            }
            else if (userIn == "4")
            {
                System.Console.Write("What is the item name? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("What is the item price? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("Is the item returnable? [T/F] ");
                rawInput = System.Console.ReadLine();
                if (rawInput.ToLower() == "f")
                {
                    atts.Add("false");
                }
                else
                {
                    atts.Add("true"); // if user put something else in, default to returnable
                }
                System.Console.Write("What is the warranty price? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("What is the warranty duration in days? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("What is the warranty description? ");
                atts.Add(System.Console.ReadLine());

                try
                {
                    Electronic electronic = new Electronic(atts[0],Convert.ToDouble(atts[1]),Convert.ToBoolean(atts[2]),Convert.ToDouble(atts[3]),Convert.ToInt32(atts[4]),atts[5]);
                    catelog.Add(electronic);
                }
                catch
                {
                    System.Console.Write("Could not construct Electronic item properly, try again. Press ENTER to continue. ");
                    System.Console.ReadLine();
                }
            }
            else if (userIn == "5")
            {
                System.Console.Write("What is the item name? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("What is the item price? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("Is the item returnable? [T/F] ");
                rawInput = System.Console.ReadLine();
                if (rawInput.ToLower() == "f")
                {
                    atts.Add("false");
                }
                else
                {
                    atts.Add("true"); // if user put something else in, default to returnable
                }
                System.Console.Write("What is the price of delivery? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("Does the item need a team carry? [T/F] ");
                rawInput = System.Console.ReadLine();
                if (rawInput.ToLower() == "f")
                {
                    atts.Add("false");
                }
                else
                {
                    atts.Add("true"); // if user put something else in, default to ask for team carry
                }

                try
                {
                    Furniture furniture = new Furniture(atts[0],Convert.ToDouble(atts[1]),Convert.ToBoolean(atts[2]),Convert.ToDouble(atts[3]),Convert.ToBoolean(atts[4]));
                    catelog.Add(furniture);
                }
                catch
                {
                    System.Console.Write("Could not construct Electronic item properly, try again. Press ENTER to continue. ");
                    System.Console.ReadLine();
                }
            }
            else if (userIn == "6")
            {
                System.Console.Write("What is the item name? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("What is the item price? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("What is the card balance? ");
                atts.Add(System.Console.ReadLine());
                System.Console.Write("Is the card reloadable? [T/F] ");
                rawInput = System.Console.ReadLine();
                if (rawInput.ToLower() == "t")
                {
                    atts.Add("true");
                }
                else
                {
                    atts.Add("false"); // if user put something else in, default to nonreloadable
                }
                
                try
                {
                    Giftcard giftcard = new Giftcard(atts[0],Convert.ToDouble(atts[1]),Convert.ToDouble(atts[2]),Convert.ToBoolean(atts[3]));
                    catelog.Add(giftcard);
                }
                catch
                {
                    System.Console.Write("Could not construct Giftcard item properly, try again. Press ENTER to continue. ");
                    System.Console.ReadLine();
                }
            }
        }
    }
    
    // Displays item names and indexes
    static string DisplayCatelog()
    {
        string catelogText = "";
        
        System.Console.Clear();
        for (int i = 0; i < catelog.Count(); i++)
        {
            catelogText += $"[{i + 1}] {catelog[i].GetName()}\n";
        }
        return catelogText;
    }
    
    // Cart functions
    static void CartMenu()
    {
        userIn = "null";

            while (userIn == "null")
            {
                Console.Clear();
                System.Console.Write("[1] Add to cart\n[2] Remove from cart\n[3] Checkout\n[4] Exit\nWhat would you like to do? ");
                userIn = System.Console.ReadLine();
                if (userIn == "1")
                {
                    AddToCart();
                }
                else if (userIn == "2")
                {
                    RemoveFromCart();
                }
                else if (userIn == "3")
                {
                    Checkout();
                }

                if (userIn == "4")
                {
                    userIn = "3"; // exit code outside the loop
                }
                else
                {
                    userIn = "null"; // keeps loop running
                }
            }

            userIn = "null"; // sets userIn so that outer loop can continue to run
    }


    static void AddToCart()
    {

    }

    static void RemoveFromCart()
    {

    }
    
    static void Checkout()
    {

    }
}