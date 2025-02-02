using System;

public static class CoinChanger
{
    public static int MinCoinCount(int amount)
    {
        int[] coins = { 50, 20, 10, 5, 1 };
        int coinCount = 0;

        foreach (var coin in coins)
        {
            coinCount += amount / coin; 
            amount %= coin;  
        }
        return coinCount;
    }
}
