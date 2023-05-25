using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_game
{
    class HangmanGame
    {

        private static string[] words = { "apple", "banana", "cherry", "date", "elderberry", "fig", "grape" };
        private static Random random = new Random();
        private static string wordToGuess;
        private static List<char> guessedLetters;
        private static int incorrectGuesses;

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            StartNewGame();

            while (true)
            {
                Console.Clear();
                DisplayHangman();
                DisplayWordToGuess();
              
                Console.Write("Enter a letter: ");

                char letter = Char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (!Char.IsLetter(letter))
                {
                    Console.WriteLine("Invalid input. Please enter a letter.");
                    continue;
                }

                if (guessedLetters.Contains(letter))
                {
                    Console.WriteLine("You have already guessed that letter.");
                    continue;
                }
                guessedLetters.Add(letter);

                if (wordToGuess.Contains(letter))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct guess!");
                    if (CheckIfWordIsGuessed())
                    {
                        Console.Clear();
                        DisplayHangman();
                        DisplayWordToGuess();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Congratulations! You have guessed the word correctly.");
                        break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect guess!");
                    incorrectGuesses++;
                    if (incorrectGuesses >= 6)
                    {
                        Console.Clear();
                        DisplayHangman();
                        DisplayWordToGuess();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Hangman is fully drawn. You have lost the game.!!");
                        break;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void StartNewGame()
        {
            wordToGuess = words[random.Next(words.Length)];
            guessedLetters = new List<char>();
            incorrectGuesses = 0;
        }

        static void DisplayHangman()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine($"  {(incorrectGuesses >= 1 ? "O" : " ")}   |");
            Console.WriteLine($" {(incorrectGuesses >= 2 ? "/" : " ")}{(incorrectGuesses >= 3 ? "|" : " ")}{(incorrectGuesses >= 4 ? "\\" : " ")}  |");
            Console.WriteLine($" {(incorrectGuesses >= 5 ? "/" : " ")} {(incorrectGuesses >= 6 ? "\\" : " ")}  |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }

        static void DisplayWordToGuess()
        {
            foreach (char letter in wordToGuess)
            {
                if (guessedLetters.Contains(letter))
                {
                    Console.Write($"{letter} ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }
            Console.WriteLine();
        }

        static bool CheckIfWordIsGuessed()
        {
            foreach (char letter in wordToGuess)
            {
                if (!guessedLetters.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        }
    }


}
        

