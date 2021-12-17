using System;
using System.Text;
using static System.Console;
using System.Collections.Generic;

namespace Hangman
{
    public class Methods
    {
        private string correctWord;
        
        public char[] GetWordFromList()
        {
            string[] wordList = new string[]
            {
                "lego", "duplo", "hotwheels"
            };

            int rndNum = new Random().Next(0, wordList.Length);
            correctWord = wordList[rndNum];

            return wordList[rndNum].ToCharArray();
        }

        public bool GuessLetter(string userInput, string alreadyGuessed, out string newUserInput)
        {
            while (alreadyGuessed.Contains(userInput))
            {
                Clear();
                WriteLine("This letter has already been guessed enter a new one.");
                userInput = ReadLine().Trim().ToLower();
            }
            newUserInput = userInput;
            if (correctWord.Contains(userInput))
            {
                return true;
            }
            return false;
        }

        public bool GuessWord(string userInput)
        {
            if (userInput.Equals(correctWord))
            {
                return true;
            }
            return false;
        }

    }
}
