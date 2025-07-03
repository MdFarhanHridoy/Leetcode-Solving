public class Solution {
    public int SubarraySum(int[] nums, int k) {
        Dictionary<int, int> sumFrequency = new Dictionary<int, int>();
        sumFrequency.Add(0, 1);
        int count = 0;
        int cumulativeSum = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            cumulativeSum += nums[i];
            
            if (sumFrequency.ContainsKey(cumulativeSum - k)) {
                count += sumFrequency[cumulativeSum - k];
            }
            
            if (sumFrequency.ContainsKey(cumulativeSum)) {
                sumFrequency[cumulativeSum]++;
            } else {
                sumFrequency.Add(cumulativeSum, 1);
            }
        }
        
        return count;
    }
}