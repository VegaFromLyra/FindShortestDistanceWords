using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// You are given a large text file containing words. 
// Given any two words, find the shortest path (in terms of number of words) between them in the file. 
// Can you make the searching operation in O(1) time ? What about the space complexity for your solution ?

// Example: 
// If a file contains the words: - "I love to eat and I love to drink". 
// And the input is 'eat' and 'drink'. The output will be 4. 
namespace FindShortestDistanceWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "Input.txt";

            string word1 = "eat";
            string word2 = "drink";

            int result = FindMinimumDistance(word1, word2, fileName);

            Console.WriteLine("Difference between {0} and {1} is {2}", word1, word2, result);
        }

        // Time complexity is O(n) and space is O(n)
        static int FindMinimumDistance(string word1, string word2, string fileName)
        {
            int min = Int32.MaxValue;

            try
            {
                List<string> words = GetWords(fileName);

                int lastPositionWord1 = -1;
                int lastPositionWord2 = -1;

                string currentWord = null;

                for (int i = 0; i < words.Count; i++)
                {
                    currentWord = words[i];

                    if (word1.Equals(currentWord))
                    {
                        lastPositionWord1 = i;

                        if (lastPositionWord2 >= 0)
                        {
                            int distance = lastPositionWord1 - lastPositionWord2;

                            if (distance < min)
                            {
                                min = distance;
                            }
                        }
                    }
                    else if (word2.Equals(currentWord))
                    {
                        lastPositionWord2 = i;

                        if (lastPositionWord1 >= 0)
                        {
                            int distance = lastPositionWord2 - lastPositionWord1;

                            if (distance < min)
                            {
                                min = distance;
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error : {0}", e.Message);
            }

            return min;
        }

        static List<string> GetWords(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            char[] separators = { ' ', '\n', '.', '\t' };

            List<string> words = new List<string>();

            foreach (string line in lines)
            {

                string[] wordsInLine = line.Split(separators);
                words.AddRange(wordsInLine.ToList());
            }

            return words;
        }
    }
}
