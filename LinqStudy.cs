using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Study
{
    public class LinqStudy
    {
        public LinqStudy()
        {
        }

        public static void Sample_Cast_Lambda()
        {
            List<string> vegetables = new List<string> { "Cucumber", "Tomato", "Broccoli" };

            var result = vegetables.Cast<string>();

            Debug.WriteLine("List of vegetables casted to a simple string array: " + result.GetType());
            foreach (string vegetable in result)
                Debug.WriteLine(vegetable);
        }

        public static void Sample_ToLookup_Lambda()
        {
            string[] words = { "one", "two", "three", "four", "five", "six", "seven" };

            var result = words.ToLookup(w => w.Contains("e"));
            foreach (string word in result[true])
                Debug.WriteLine(word);
        }
    }
}