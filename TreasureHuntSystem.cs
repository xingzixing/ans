using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TreasureHuntSystem
{
    public static int MaxTreasureValue(int[] treasures)
    {
        // 
        int[] dp = new int[treasures.Length + 1];
        dp[0] = 0;
        dp[1] = treasures[0];
        for (int i = 2; i <= treasures.Length; i++)
        {
            dp[i] = Math.Max(treasures[i - 1] + dp[i-2], dp[i - 1]);
        }
        return dp[treasures.Length];

    }
}
public class TestTreasureHuntSystem
{
    public void TesMaxTreasureValue()
    {
        // 
        int[] treasures = { 3, 1, 5, 2, 4 };
        var ret = TreasureHuntSystem.MaxTreasureValue(treasures);
        Console.WriteLine(ret);

    }
}
