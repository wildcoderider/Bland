using System;
namespace BlandGroup
{
	public class PalindromeChecker
	{
        public static bool IsPalindrome(string word)
        {
            
            
            string cleanInput = new string(word.Where(char.IsLetterOrDigit).ToArray()).ToLower();

            // Comparation
            return cleanInput == new string(cleanInput.Reverse().ToArray());
        }
    }
}

