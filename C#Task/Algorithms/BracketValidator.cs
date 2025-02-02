using System;

public static class BracketValidator
{
    public static bool IsProperly(string sequence)
    {
        int balance = 0;

        foreach (char c in sequence)
        {
            if (c == '(')
                balance++;
            else if (c == ')')
                balance--;

          
            if (balance < 0)
                return false;
        }

      
        return balance == 0;
    }
}
