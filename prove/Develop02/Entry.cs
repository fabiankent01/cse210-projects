using System;

public class Entry
{
    public string  _date ;
    public string _time;
    public string _promptText = "";
    public string _entryText = "";

    public void Display()
    {
        Console.WriteLine($"\nDATE: {_date} \nTIME: {_time}\nPROMPT: {_promptText}\nENTRY: {_entryText}");
    }
}