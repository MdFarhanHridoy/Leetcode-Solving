public class Solution {
    public int FindMaxLength(int[] nums) {
        Dictionary<int, int> countMap = new Dictionary<int, int>();
        countMap.Add(0, -1);
        int maxLength = 0;
        int count = 0;
        
        for (int i = 0; i < nums.Length; i++) {
            count += (nums[i] == 1 ? 1 : -1);
            
            if (countMap.ContainsKey(count)) {
                maxLength = Math.Max(maxLength, i - countMap[count]);
            } else {
                countMap.Add(count, i);
            }
        }
        
        return maxLength;
    }
}