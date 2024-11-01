using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class TalentAssessmentSystem
{
    public static double FindMedianTalentIndex(int[] fireAbility, int[]
iceAbility)
    {
        int n = fireAbility.Length;
        int m = iceAbility.Length;
        int left = (n + m + 1) / 2;
        int right = (n + m + 2) / 2;
        return (findK(fireAbility, 0, n - 1, iceAbility, 0, m - 1, left) + findK(fireAbility, 0, n - 1, iceAbility, 0, m - 1, right)) * 0.5;
    }
    public static float findK(int[] fireAbility, int start1, int end1,
    int[] iceAbility, int start2, int end2, int k)
    {
        if (start1 > end1)
        {
            return iceAbility[start2 + k - 1];
        }
        int len1 = end1 - start1 + 1;
        int len2 = end2 - start2 + 1;
        if (len1 > len2)
        {
            return findK(iceAbility, start2, end2, fireAbility, start1, end1, k);
        }
        //返回小的
        if (k == 1)
        {
            return Math.Min(fireAbility[start1], iceAbility[start2]);
        }
        //找k/2,比较index
        int i = start1 + Math.Min(len1, k / 2) - 1;
        int j = start2 + Math.Min(len2, k / 2) - 1;
        //k不在nums2
        if (fireAbility[i] > iceAbility[j])
        {
            return findK(fireAbility, start1, end1, iceAbility, j + 1, end2, k - (j - start2 + 1));
        }
        else
        {
            return findK(fireAbility, i + 1, end1, iceAbility, start2, end2, k - (i - start1 + 1));
        }
    }
}

public class TalentAssessmentSystemTests
{

    public void TestFindMedianTalentIndex()
    {
        // 
        int[] fireAbility = { 1, 3, 7, 9, 11 };
        int[] iceAbility = { 2, 4, 8, 10, 12, 14};
        var ret = TalentAssessmentSystem.FindMedianTalentIndex(fireAbility, iceAbility);
        Console.WriteLine(ret);


    }
}