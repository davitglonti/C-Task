using System;
using System.Collections.Generic;

public static class MissingNumber
{
    public static int NotContains(int[] array)
    {
        HashSet<int> numbers = new HashSet<int>(array);
        int smallest = 1; 

        while (numbers.Contains(smallest))
        {
            smallest++; 
        }

        return smallest;
    }
}
