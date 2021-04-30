using System;
using System.Linq;

namespace CodeSignalExercises
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var result = reverseInParentheses("foo(bar(baz))blim");
            Console.WriteLine("the word is " + result);
        }

        #region reverseInParentheses

        public static string ReverseInParentheses(string inputString)
        {
            var phraseAsArray = inputString.ToCharArray();
            var finalPhrase = string.Empty;

            for (int i = 0; i < phraseAsArray.Length; i++)
            {
                if (phraseAsArray[i] == '(')
                {
                    var a = new string(phraseAsArray).Substring(i + 1);
                    var reversedword = GetReversedWord(a.ToCharArray());
                    finalPhrase += reversedword;
                    i = i + reversedword.Length + 1;
                    continue;
                }
                else
                {
                    finalPhrase += phraseAsArray[i];
                }
            }
            return finalPhrase.Contains("(") ? ReverseInParentheses(finalPhrase) : finalPhrase;
        }

        private static string GetReversedWord(char[] restOfWord)
        {
            var reversedWord = string.Empty;
            for (int i = 0; i < restOfWord.Length; i++)
            {
                if (restOfWord[i] == ')')
                {
                    var result = reversedWord.ToCharArray();
                    Array.Reverse(result);
                    return new string(result);
                }
                else
                {
                    reversedWord += restOfWord[i];
                }
            }
            return reversedWord;
        }

        #endregion reverseInParentheses

        #region BetterSolution reverseInParentheses

        public static string reverseInParentheses(string inputString)
        {
            while (inputString.Contains("("))
            {
                var lastParenthesis = inputString.LastIndexOf("(") + 1;
                var word = new string(inputString.Skip(lastParenthesis).TakeWhile(l => l != ')').Reverse().ToArray());
                var lastWord = "(" + new string(word.Reverse().ToArray()) + ")";
                inputString = inputString.Replace(lastWord, word);
            }
            return inputString;
        }

        #endregion BetterSolution reverseInParentheses
    }
}