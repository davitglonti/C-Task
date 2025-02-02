public static class Staircase
{
    public static int CountVariants(int stairCount)
    {
        if (stairCount == 1) return 1;
        if (stairCount == 2) return 2;

        int prev1 = 2, prev2 = 1, current = 0;

        for (int i = 3; i <= stairCount; i++)
        {
            current = prev1 + prev2;
            prev2 = prev1;
            prev1 = current;
        }

        return current;
    }
}
