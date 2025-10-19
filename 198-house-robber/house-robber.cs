public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;
        if (n == 0) return 0;
        if (n == 1) return nums[0];
        
        int prev2 = nums[0];          // dp[i-2]
        int prev1 = Math.Max(nums[0], nums[1]); // dp[i-1]
        
        for (int i = 2; i < n; i++) {
            int current = Math.Max(prev1, nums[i] + prev2);
            prev2 = prev1;
            prev1 = current;
        }
        
        return prev1;
    }
}