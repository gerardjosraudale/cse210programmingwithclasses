using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture("1 Nephi 3:7", "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.")
        };

        Console.WriteLine("Welcome to Scripture Memorizer");
        foreach (var scripture in scriptures)
        {
            Console.WriteLine($"Scripture Reference: {scripture.Reference}");
            Console.WriteLine(scripture.Text);
        }

        Console.WriteLine("Press Enter to start hiding words or type 'quit' to finish.");
        if (Console.ReadLine() == "quit")
        {
            return;
        }

        Random random = new Random();
        int scriptureIndex = 0;

        while (scriptureIndex < scriptures.Count)
        {
            var selectedScripture = scriptures[scriptureIndex];
            string[] words = selectedScripture.Text.Split(' ');

            int wordsToHide = random.Next(1, words.Length);
            List<int> indicesToHide = Enumerable.Range(0, words.Length).ToList();
            indicesToHide = indicesToHide.OrderBy(x => random.Next()).ToList();
            indicesToHide = indicesToHide.GetRange(0, wordsToHide);

            Console.Clear();
            Console.WriteLine($"Scripture Reference: {selectedScripture.Reference}");
            
            for (int i = 0; i < words.Length; i++)
            {
                if (indicesToHide.Contains(i))
                {
                    words[i] = new string('*', words[i].Length);
                }
            }

            string hiddenScripture = string.Join(" ", words);
            Console.WriteLine(hiddenScripture);

            Console.WriteLine("Press Enter to continue or type 'quit' to finish.");
            string input = Console.ReadLine();

            if (input == "quit")
            {
                break;
            }

            scriptureIndex++;
        }
    }
}

class Scripture
{
    public string Reference { get; }
    public string Text { get; }

    public Scripture(string reference, string text)
    {
        Reference = reference;
        Text = text;
    }
}
