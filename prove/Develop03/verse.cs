public class Verse
{
    private String _verseNum;
    private List<Word> _wordList = [];
    private List<Word> _keptWordList = [];

    public Verse()
    {
        _verseNum = "N/A";
    }

    public Verse(String verseNum, String verseText)
    {
        _verseNum = verseNum;

        var words = verseText.Split(" ");
        foreach(String w in words)
        {
            Word word = new Word(w);
            _wordList.Add(word);
            _keptWordList.Add(word);
        }
    }

    public List<Word> getWordList()
    {
        return _wordList;
    }

    public void HideWord()
    {
        for (int i = 0; i < 3; i++)
        {
            Random rand = new Random();
            int randIndex = rand.Next(_keptWordList.Count());
            System.Console.WriteLine($"W:{randIndex}");

            Word randWord = _keptWordList[randIndex];

            randWord.SetHidden();
            _keptWordList.Remove(_keptWordList[randIndex]); // Removes word from list of unhidden words

            if (IsFinished()) // To prevent an error if the number of words isn't divisible by 3
            {
                break;
            }
        }
    }

    public Boolean IsFinished()
    {
        foreach(Word w in _wordList)
        {
            if (w.GetHidden())
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
        String holeyText = "";
        foreach(Word w in _wordList)
        {
            if (w.GetHidden())
            {
                holeyText += $" {w.GetEmpty()}";
            }
            else
            {
                holeyText += $" {w.GetWord()}";
            }
        }
        System.Console.WriteLine($"{_verseNum}{holeyText}");
    }
}