using System;

class Program
{
    static void Main(string[] args)
    {
        // First constructor takes user input, this example takes the reference and the number of verses, which is 1
        Scripture scrip1 = new Scripture("1 Nephi 2:15",1);
        // When prompted for the verse number, enter 15
        // When prompted for the verse text, paste the following line:
        // And my father dwelt in a tent.

        HideCycle(scrip1); 
        // A separate list of unhidden verses is stored in Scripture, and a list of unhidden words in each verse, 
        // ensuring only words not already hidden are hidden

        System.Console.WriteLine("\nPress enter to go to the next example Scripture.");
        System.Console.ReadLine();
        Console.Clear();

        // Second constructor takes no user input, this example takes the reference and a list of strings, and numbers the verses in order of appearance
        Scripture scrip2 = new Scripture("Alma 11:3-6",
        [
            "And the judge received for his wages according to his time—a senine of gold for a day, or a senum of silver, which is equal to a senine of gold; and this is according to the law which was given.",
            "Now these are the names of the different pieces of their gold, and of their silver, according to their value. And the names are given by the Nephites, for they did not reckon after the manner of the Jews who were at Jerusalem; neither did they measure after the manner of the Jews; but they altered their reckoning and their measure, according to the minds and the circumstances of the people, in every generation, until the reign of the judges, they having been established by king Mosiah.",
            "Now the reckoning is thus—a senine of gold, a seon of gold, a shum of gold, and a limnah of gold.",
            "A senum of silver, an amnor of silver, an ezrom of silver, and an onti of silver."
        ]
        );

        HideCycle(scrip2);
        // When displaying verses using this constructor, regardless of how many verses the proper suffix will be attached to the verse (ex. "113th Verse:")
    }

    static void HideCycle(Scripture scrip)
    {
        String userIn = "";

        scrip.Display();
        System.Console.WriteLine("\nPress enter to remove a word.\nPress any key and enter to exit.");

        while (userIn == "")
        {
            userIn = System.Console.ReadLine();
            if (userIn.ToLower() == "quit")
            {
                continue;
            }
            else
            {
                userIn = "";
            }

            scrip.HideWord();
            System.Console.Clear();
            scrip.Display();

            System.Console.WriteLine("\nPress enter to remove a word.\nType QUIT and enter to exit.");

            if (scrip.IsFinished())
            {
                return;
            }
        }
    }
}