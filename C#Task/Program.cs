using System;

namespace C_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task 1
            string input = "aa"; 
            bool result = Palindrome.sPalindrome(input);
            Console.WriteLine(result ? "Palindrome!" : "not palindrome!");
            //
            //task 2
            int amount = 87; 
            int results = CoinChanger.MinCoinCount(amount);
            Console.WriteLine($"min coins: {results}");
        }
    }
}
