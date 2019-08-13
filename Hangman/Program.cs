using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman {
    class Program {

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

        public static void PlayGame(List<string> phrases) {
            string phrase;
            phrase = SelectPhrase(phrases);
        }

        public static char[] GetPhraseCharacters(string phrase) {
            phrase = phrase.ToUpper();
            char[] phraseArray = phrase.ToCharArray();
            return phraseArray;
        }

        public static HashSet<char> GetPhraseDistinctCharacters (char[] phraseCharacters) {
            HashSet<char> distinctChars = new HashSet<char>();
            for (int count=0; count<phraseCharacters.Length; count++) {
                if (phraseCharacters[count]==' ') {
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

        static void Main(string[] args) {

            Console.WriteLine("Welcome to the Word Guess app!");
            Console.ReadKey();

            var phrases = GetPhrases();
            PlayGame(phrases);
        }
    }
}
