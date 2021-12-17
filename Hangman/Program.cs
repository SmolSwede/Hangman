using System;
using System.Text;
using static System.Console;

namespace Hangman
{
    public class Program
    {
        static void Main(string[] args)
        {
            Methods methods = new Methods();

            int wrongCounter = 10;
            string guessedLetters = "";
            char[] correctLetters = methods.GetWordFromList();
            char[] wordToReveal = new char[correctLetters.Length];
            wordToReveal = new StringBuilder().Append('-', correctLetters.Length).ToString().Trim().ToCharArray();

            WriteLine("Welcome to the Hangman Game!" +
                      "\n" +
                      "\nYou have 10 tries to guess the correct word." +
                      "\n");
            for(int i = 0; i < (10 + correctLetters.Length); i++)
            {
                if(wrongCounter == 0)
                {
                    break;
                }

                WriteLine($"The word is {string.Concat(wordToReveal)}" +
                          $"\nGuessed letters [{guessedLetters}]" +
                          $"\nYour amount of guesses left are {wrongCounter}");

                string userInput = ReadLine().Trim().ToLower();

                if(userInput.Length > 1)
                {
                    Clear();
                    if(methods.GuessWord(userInput) == true)
                    {
                        WriteLine($"You guessed correctly the word was {string.Concat(correctLetters)}");
                        ReadKey();
                        break;
                    }
                    else
                    {
                        wrongCounter--;
                        WriteLine("Your guess was wrong");
                        ReadKey();
                    }
                }
                else if(userInput.Length <= 1)
                {
                    Clear();
                    if (methods.GuessLetter(userInput, guessedLetters, out userInput) == true)
                    {
                        guessedLetters = guessedLetters + new StringBuilder().Append(userInput + ".");
                        for(int j = 0; j < correctLetters.Length; j++)
                        {
                            if (userInput.Contains(correctLetters[j]))
                            {
                                wordToReveal[j] = correctLetters[j];
                            }
                        }
                        WriteLine($"Your guess was correct [{string.Concat(wordToReveal)}]");
                        ReadKey();
                    }
                    else
                    {
                        wrongCounter--;
                        WriteLine("Your guess was wrong");
                        ReadKey();
                    }
                }
                
            }
        }
    }
}
            
