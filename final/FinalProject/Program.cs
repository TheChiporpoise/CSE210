using System;

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
                AddToCatelog();
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
                    System.Console.WriteLine($"{i} [Food] failed at index {i}");
                    corrupt++;
                }
            }
            else if (semi[i][0] == '2')
            {
                // try
                // {
                //     Produce produce = new Produce(semi[i]);
                //     catelog.Add(produce);
                // }
                // catch
                // {
                //     System.Console.WriteLine($"{i} [Produce] failed at index {i}");
                //     corrupt++;
                // }
            }
            else if (semi[i][0] == '3')
            {
                // try
                // {
                //     ChecklistGoal checklist = new ChecklistGoal(semi[i]);
                //     goalList.Add(checklist);
                // }
                // catch
                // {
                //     System.Console.WriteLine($"Checklist failed at index {i}");
                //     corrupt++;
                // }
            }
            else
            {
                corrupt++;
            }
        }
        if (0 < corrupt) {
            System.Console.Write($"{corrupt} goals could not be loaded properly. Press ENTER to continue.");
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
            System.Console.Write("[1] Edit Name\n[2] Edit Price\n[3] Change return policy\n[4] RECALL\n[5] Display Attributes\n [6] Remove Item\n[7] Exit\nWhat would you like to do? ");
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
    static void AddToCatelog()
    {
        
    }
    
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