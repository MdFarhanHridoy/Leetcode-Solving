public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        Backtrack(nums, 0, new List<int>(), result);
        return result;
    }
    
    private void Backtrack(int[] nums, int start, List<int> current, IList<IList<int>> result) {
        // Add the current subset to the result
        result.Add(new List<int>(current));
        
        // Generate subsets by including each element one by one
        for (int i = start; i < nums.Length; i++) {
            current.Add(nums[i]); // Include nums[i]
            Backtrack(nums, i + 1, current, result); // Move to next element
            current.RemoveAt(current.Count - 1); // Backtrack (exclude nums[i])
        }
    }
}