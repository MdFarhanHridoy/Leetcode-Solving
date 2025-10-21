public class Solution {
    public int LengthOfLIS(int[] nums) {
        if (nums == null || nums.Length == 0) return 0;
        
        int[] tails = new int[nums.Length];
        int size = 0;
        
        foreach (int num in nums) {
            int left = 0, right = size;
            
            // Binary search to find the position to replace/append
            while (left < right) {
                int mid = left + (right - left) / 2;
                if (tails[mid] < num) {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
            
            tails[left] = num;
            if (left == size) size++;
        }
        
        return size;
    }
}