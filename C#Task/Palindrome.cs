using System;

public static class Palindrome
{
    public static bool sPalindrome(string text)
    {
        
        string cleanedText = text.ToLower().Replace(" ", "").Replace(",", "").Replace(".", "");

        
        char[] arr = cleanedText.ToCharArray();
        Array.Reverse(arr);
        string reversedText = new string(arr);

        return cleanedText == reversedText;
    }
}