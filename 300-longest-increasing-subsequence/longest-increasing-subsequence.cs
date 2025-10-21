public class Solution {
    public int LengthOfLIS(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;
        
        int[] dp = new int[nums.Length];
        Array.Fill(dp, 1);
        int maxLength = 1;
        
        for (int i = 1; i < nums.Length; i++) {
            for (int j = 0; j < i; j++) {
                if (nums[i] > nums[j]) {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
            maxLength = Math.Max(maxLength, dp[i]);
        }
        
        return maxLength;
    }
}