using System;
using System.Numerics;
using System.Threading.Channels;

namespace Hangman
{
    class Program
    {
        static string correctWord;
        static char[] letters;
        static Player player;

        static void Main(string[] args)
        {
            StartGame();
            PlayGame();
            EndGame();
        }

        private static void StartGame()
        {
            var words = File.ReadAllLines(@"C:\Users\albos\source\repos\albossmohammad83\Hangman-game\Hangman\Words.txt");

            Random random = new Random();
            correctWord = words[random.Next(0, words.Length)];

            letters = new char[correctWord.Length];
            for (int i = 0; i < correctWord.Length; i++)
            {
                letters[i] = '-';
            }
            AskForUsersName();
        }

        static void AskForUsersName()
        {
            Console.WriteLine("Enter your name:");
            string input = Console.ReadLine();
            if (input.Length >= 2)
            {
                player = new Player(input);
            }
            else
            {
                AskForUsersName();
            }
            Console.Clear();
        }

        private static void PlayGame()
        {
            do
            {
                DisplayMaskedWord();
                char guessedLetters = AskForLetter();
                CheckLetters(guessedLetters);
                Console.Clear();
            } while (correctWord!= new string(letters));

            Console.Clear();
        }

        private static void CheckLetters(char guessedLetters)
        {
            for (int i = 0; i < correctWord.Length; i++)
            {
                if (guessedLetters == correctWord[i])
                {
                    letters[i] = guessedLetters;
                    player.Score++;
                }
            }
        }

        static void DisplayMaskedWord()
        {
            foreach (char c in letters)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }

        static char AskForLetter()
        {
            string input;
            do
            {
                Console.WriteLine("Enter a letter:");
                input = Console.ReadLine();
            } while (input.Length != 1);

            var letter = input[0];

            if (!player.guessedLetters.Contains(letter))
            {
                player.guessedLetters.Add(letter);
            }

            return letter;
        }
        private static void EndGame()
        {
            Console.WriteLine("Game over...");
            Console.WriteLine($"Thanks for playing {player.Name}");
            Console.WriteLine($"Guesses:{player.guessedLetters.Count} Score:{player.Score}");
        }
    }
}
