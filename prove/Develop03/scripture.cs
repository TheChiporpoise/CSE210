public class Scripture
{
    private String _ref;
    private List<Verse> _verseList = [];
    private List<Verse> _keptVerseList = [];
    

    public Scripture()
    {
        _ref = "N/A";
    }

    public Scripture(String fullRef, int verseCount)
    {
        _ref = fullRef;

        int i = 0;
        while (i < verseCount)
        {
            System.Console.Write("Enter verse number: ");
            String verseNum =  System.Console.ReadLine();
            System.Console.Write("Paste verse text: ");
            String verseText =  System.Console.ReadLine();

            Verse verse = new Verse(verseNum, verseText);
            _verseList.Add(verse);
            _keptVerseList.Add(verse);

            i++;
        }
    }

    public Scripture(String fullRef, List<String> scripList)
    {
        _ref = fullRef;

        int i = 1;
        String nth;
        foreach (String v in scripList)
        {
            // Lines 42-56 determine the proper suffix for the verse number
            List<String> nthList =["th", "st", "nd", "rd"];
            int iMod = i % 100;
            if (Math.Abs(iMod - 20) % 10 < 4)
            {
                
                nth = nthList[Math.Abs(iMod - 20) % 10];
            }
            else if (iMod < 4)
            {
                nth = nthList[iMod];
            } 
            else
            {
                nth = nthList[0];
            }
            
            String verseNum =  $"{i}{nth} Verse: "; // For simplicity's sake, it just numbers the verses in order of appearance
            String verseText =  v;

            Verse verse = new Verse(verseNum, verseText);
            _verseList.Add(verse);
            _keptVerseList.Add(verse);

            i++;
        }
    }

    public void HideWord()
    {
        Random rand = new Random();
        int randIndex = rand.Next(_keptVerseList.Count());
        System.Console.WriteLine($"V:{randIndex}");

        Verse randVerse = _keptVerseList[randIndex];
        randVerse.HideWord();

        if (randVerse.IsFinished())
        {
            _keptVerseList.Remove(randVerse);
        }
    }

    public Boolean IsFinished()
    {
        foreach(Verse v in _verseList)
        {
            if (v.IsFinished())
            {}
            else
            {
                return false;
            }
        }
        return true;
    }

    public void Display()
    {
        System.Console.WriteLine(_ref);
        foreach(Verse v in _verseList)
        {
            v.Display();
        }
    }
}