using System;
using System.Collections.Generic;

using System.Threading;


public class LeaderboardSystem
{

    public static List<int> GetTopScores(int[] scores, int m)
    {
        // 
        List<int> ans = new List<int>();
        initHeap(ref scores);
        int length = scores.Length - 1;
        m = Math.Min(length + 1, m);
        for (int i = 0; i < m; i++)
        {
            swap(ref scores, 0, length);
            ans.Add(scores[length]);
            length--;
            makeHeap(ref scores, 0, length);
        }
        return ans;
    }
    public static void swap(ref int[] scores, int i, int j)
    {
        int temp = scores[i];
        scores[i] = scores[j];
        scores[j] = temp;
    }
    public static void initHeap(ref int[] scores)
    {

        for (int i = scores.Length / 2; i >= 0; i--)
        {
            makeHeap(ref scores, i, scores.Length - 1);
        }
    }
    public static void makeHeap(ref int[] scores, int i, int n)
    {
        while (2 * i + 1 <= n)
        {
            int largeIndex = i;
            int lc = 2 * i + 1;
            int rc = 2 * i + 2;
            if (lc <= n && scores[lc] > scores[largeIndex])
            {
                largeIndex = lc;
            }
            if (rc <= n && scores[rc] > scores[largeIndex])
            {
                largeIndex = rc;
            }

            if (largeIndex != i)
            {
                swap(ref scores, i, largeIndex);
                i = largeIndex;
            }
            else
            {
                break;
            }
        }
    }
}
public class LeaderboardSystemTests
{
    static void Main(string[] args)
    {
        int a = 32;
        Object b = a;
        a++;
        Console.WriteLine((int)b);
        Thread.Sleep(10000);
    }
    public void TestGetTopScores(int[] scores, int m)
    {
        var ret = LeaderboardSystem.GetTopScores(scores, m);
        Console.WriteLine("scoces:");
        foreach (int i in scores)
       
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
        Console.WriteLine("GetTopScores " + m + ":");
        foreach (var n in ret)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
    }
    public void TestGetTopScores()
    {
        //
        int[] first = { };
        TestGetTopScores(first, 4);

        int[] second = { 100, 50, 75, 80, 65 };
        TestGetTopScores(second, 3);

    }
}


