public class Word
{
    private String _text;
    private String _emptyText = "";
    private Boolean _hidden = false;

    public Word()
    {
        _text = "N/A";
    }

    public Word(String text)
    {
        _text = text;
        for (int i = 0; i < text.Length; i++)
        {
            _emptyText += "_";
        }
    }

    public String GetWord()
    {
        return _text;
    }

    public String GetEmpty()
    {
        return _emptyText;
    }

    public Boolean GetHidden()
    {
        return _hidden;
    }

    public void SetHidden()
    {
        _hidden = true;
    }
}