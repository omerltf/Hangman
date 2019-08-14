using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman {
    class Program {
        static int incorrectGuesses = 0;

        public static List<string> GetPhrases() {
            List<string> phrasesList = new List<string>();
            phrasesList.Add("Harry Potter and the Prisoner of Azkaban");
            phrasesList.Add("There is no try");
            phrasesList.Add("Another One Bites the Dust");
            phrasesList.Add("May the Force be with you");
            phrasesList.Add("You cant handle the truth");
            phrasesList.Add("With great power comes great responsibility");

            return phrasesList;
        }

        public static string SelectPhrase(List<string> phrases) {
            var random = new Random();
            var randomInteger = random.Next(0, phrases.Count);
            return phrases.ElementAt(randomInteger);
        }

        public static void DisplayPhrase(char[] phrase, List<char> phraseGuessedCharacters) {
            for (int count = 0; count < phrase.Length; count++) {
                if (phrase[count] == ' ' || phraseGuessedCharacters.Contains(phrase[count])) {
                    Console.Write(phrase[count]);
                }
                else {
                    Console.Write("X");
                }
            }
            Console.WriteLine();
        }

        public static HashSet<char> GetPhraseDistinctCharacters(char[] phraseCharacters) {
            HashSet<char> distinctChars = new HashSet<char>();
            for (int count = 0; count < phraseCharacters.Length; count++) {
                if (phraseCharacters[count] == ' ') {
                    continue;
                }
                else if (distinctChars.Contains(phraseCharacters[count])) {
                    continue;
                }
                else {
                    distinctChars.Add(phraseCharacters[count]);
                }
            }
            return distinctChars;
        }

        public static char[] GetPhraseCharacters(string phrase) {
            phrase = phrase.ToUpper();
            char[] phraseArray = phrase.ToCharArray();
            return phraseArray;
        }

        public static char GetCharacterGuess(List<char> guessedCharacters) {
            while (true) {
                Console.Write("What do you guess (A-Z)? ");
                ConsoleKeyInfo selectedOption = Console.ReadKey();
                Console.WriteLine();
                char tempChar = selectedOption.KeyChar;
                tempChar = char.ToUpper(tempChar);
                if (!(tempChar >= 'A' && tempChar <= 'Z')) {
                    Console.WriteLine("Incorrect input. Please try again.");
                    continue;
                }
                else if (guessedCharacters.Contains(tempChar)) {
                    Console.WriteLine("You already guessed {0}. Please try again.", tempChar);
                    continue;
                }
                else {
                    Console.Clear();
                    return tempChar;
                }
            }
        }

        public static void PlayGame(List<string> phrases) {
            string phrase;
            phrase = SelectPhrase(phrases);
            char[] phraseCharacters = GetPhraseCharacters(phrase);
            HashSet<char> phraseDistinctCharacters = GetPhraseDistinctCharacters(phraseCharacters);
            List<char> phraseGuessedCharacters = new List<char>();
            DisplayPhrase(phraseCharacters, phraseGuessedCharacters);
            Console.Clear();
            const int maxGuesses = 5;
            List<char> guessedCharacters = new List<char>();

            while (true) {
                DisplayPhrase(phraseCharacters, phraseGuessedCharacters);
                guessedCharacters.Add(GetCharacterGuess(guessedCharacters));
                if (phraseDistinctCharacters.Contains(guessedCharacters.Last())) {
                    Console.WriteLine("You chose WISELY. Good Job!");
                    phraseGuessedCharacters.Add(guessedCharacters.Last());
                    if (phraseGuessedCharacters.Count == phraseDistinctCharacters.Count) {
                        Console.WriteLine("You Did It! Congrats.");
                        Console.WriteLine();
                        DisplayPhrase(phraseCharacters, phraseGuessedCharacters);
                        Console.ReadKey();
                        break;
                    }
                    else {
                        continue;
                    }
                }
                else {
                    incorrectGuesses += 1;
                    if (maxGuesses - incorrectGuesses < 0) {
                        Console.WriteLine("You Lost! Better Luck Next Time.");
                        Console.WriteLine("The real phrase was: {0}", phrase);
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("You chose POORLY! You have {0} guesses left", maxGuesses-incorrectGuesses);
                }
            }
        }

        static void Main(string[] args) {

            Console.WriteLine("Welcome to the Word Guess app!");
            Console.ReadKey();

            var phrases = GetPhrases();
            PlayGame(phrases);
        }
    }
}