using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string bookName, int chapter, int chapterVerse)
    {
        _book = bookName;
        _chapter = chapter;
        _verse = chapterVerse;
    }

    public Reference(string bookName, int chapter, int chapterVerse, int chapterEndVerse)
    {
        _book = bookName;
        _chapter = chapter;
        _verse = chapterVerse;
        _endVerse = chapterEndVerse;
    }

    public string GetDisplayText()
    {
        if (_endVerse == 0)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}