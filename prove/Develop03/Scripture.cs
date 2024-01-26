using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] words = text.Split(' ');
        foreach (string wrd in words)
        {
            _words.Add(new Word(wrd));
        }
    }

    public void HideRandomWords (int numberToHide)
    {
    //     Random random = new Random();
    //     for (int i = 0; i < numberToHide; i++)
    //    { 
    //         int number = random.Next(_words.count);
    //         randomWord = _words[number];
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < numberToHide)
        {
            int randomIndex = random.Next(_words.Count);
            Word wordToHide = _words[randomIndex];

            if (!wordToHide.IsHidden())
            {
                wordToHide.Hide();
                hiddenCount += 1;
            }
        }
    }

    public string GetDisplayText()
    {
        string displayText = "" ;

        foreach (Word word in _words)
        {
            displayText = displayText + word.GetDisplayText() + " ";
        }

        return $"{_reference.GetDisplayText()}  {displayText.Trim()}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}