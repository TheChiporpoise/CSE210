using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        String _response;

        while (true)
        {
            System.Console.Clear();
            System.Console.Write("Menu Options:\n  1. Start breathing activity\n  2. Start reflecting activity\n  3. Start listing activity\n  4. Quit\nSelect an option from the menu: ");
            _response = System.Console.ReadLine();

            if (_response == "1")
            {
                Breathe activity = new Breathe("Breathing");
                activity.DoActivity();
            }
            else if (_response == "2")
            {
                Reflect activity = new Reflect("Reflection");
                activity.DoActivity();
            }
            else if (_response == "3")
            {
                Listing activity = new Listing("Listing");
                activity.DoActivity();
            }
            else if (_response == "4")
            {
                break;
            }
            else
            {
                continue;
            }
        }
    }
}