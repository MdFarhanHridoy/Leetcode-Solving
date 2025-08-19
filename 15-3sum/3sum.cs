using System;
using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();
        int n = nums.Length;
        
        for (int i = 0; i < n - 2; i++) {
            if (i > 0 && nums[i] == nums[i-1]) continue; // Skip duplicates for the first element
            
            int left = i + 1;
            int right = n - 1;
            
            while (left < right) {
                int sum = nums[i] + nums[left] + nums[right];
                if (sum == 0) {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });
                    while (left < right && nums[left] == nums[left+1]) left++; // Skip duplicates for left
                    while (left < right && nums[right] == nums[right-1]) right--; // Skip duplicates for right
                    left++;
                    right--;
                } else if (sum < 0) {
                    left++;
                } else {
                    right--;
                }
            }
        }
        
        return result;
    }
}