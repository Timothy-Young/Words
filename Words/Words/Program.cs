using System;
using System.Collections.Generic;
using System.Linq;

namespace Words
{
  public class Program
  {
    public static void Main(string[] args)
    {
      string[] list = new string[] {"good", "bad", "dog", "cat", "do", "dont" };
      string input = "ddelgoo";
      Console.WriteLine("Example output: [\"good\", \"dog\", \"do\"]");
      Console.WriteLine($"Matched output: [\"{string.Join("\",\"", FindWords(input, list))}\"]");
      Console.ReadLine();
    }

    public static string[] FindWords(string input, string[] words)
    {
      List<string> wordsFound = new List<string>();
      
      // loop through list of words
      foreach(string word in words)
      {
        // verify all letters in word are in input and are used per word in words
        if (word.All(c => input.Contains(c) && word.GroupBy(l => l).All(w => w.Count() <= input.Count(l => l == w.Key))))
        {
          // word found, add to list
          wordsFound.Add(word);
        }
      }
      return wordsFound.ToArray();
    }
  }
}
