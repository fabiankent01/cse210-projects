using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
        Console.WriteLine("Your entry has been added to your Journal");
    }

    public void DisplayAll()
    {
        for (int i=0; i < _entries.Count; i++)
        {
            Entry entry = _entries[i];
            entry.Display();
        }   
        Console.WriteLine("\nIncrease your console size to get the best view.");

    }
    // public void SaveToFile(string file)
    // {
    //     using (StreamWriter userFile = new StreamWriter(file))
    //     {
    //         foreach (Entry entry in _entries)
    //         {
    //             userFile.WriteLine($"\nDATE: {entry._date}\nTIME: {entry._time}\nPROMPT:{entry._promptText}\nENTRY:{entry._entryText}");
    //         }
    //         Console.WriteLine("Your file has been saved.");
    //     }
    // }

    //found another way that appends new stuff to the file and doesn't delete the old stuff
    public void SaveToFile(string file)
    {
        string fileContent = "";

        foreach (Entry entry in _entries)
        {
            fileContent += $"\nDATE: {entry._date}\nTIME: {entry._time}\n";
            fileContent += $"PROMPT:{entry._promptText}\nENTRY:{entry._entryText}\n";
        }

        File.AppendAllText(file, fileContent);
        Console.WriteLine("Your file has been saved.");
    }

    public void LoadFromFile(string file)
    {
        string[] lines = System.IO.File.ReadAllLines(file);
        //loop through all the lines in the file
        //(JUST LIKE YOU'D DO IN PYTHON)
        foreach (string line in lines)
        {
            Console.WriteLine(line);
            //I'd use this if I had to split but nope, not splitting
            // string[] parts = line.Split(",");
            // string date = parts[0];
            // string prompt = parts[1];
            // string entry = parts[2];

            // Console.WriteLine($"DATE: {date}\nPROMPT: {prompt}\nENTRY: {entry}");
        }
        Console.WriteLine("\nIncrease your console size to get the best view.");
    } 
}
