using System;
using System.Threading;

public class EnergyFieldSystem
{
    public static float MaxEnergyField(int[] heights)
    {
        int left = 0;
        int right = heights.Length - 1;
        float maxV = (float)(right - left) * ((float)(heights[left] +  heights[right]))/2;
        while (left < right)
        {
            if (heights[left] < heights[right])
            {
                left++;
            }
            else
            {
                right--;
            }
            float currV = (float)(right - left) * ((float)(heights[left] + heights[right])) / 2;
            maxV = maxV > currV ? maxV : currV;
        }
        return maxV;
    }
    public class EnergyFieldSystemTests
    {

        public void TestMaxEnergyField()
        {
            // 
            int[] heights = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            var ret = EnergyFieldSystem.MaxEnergyField(heights);
            Console.WriteLine(ret);

        }
    }
    
}
