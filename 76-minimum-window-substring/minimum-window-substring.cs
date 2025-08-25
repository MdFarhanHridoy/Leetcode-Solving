public class Solution {
    public string MinWindow(string s, string t) {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length) {
            return "";
        }
        
        // Count frequency of characters in t
        Dictionary<char, int> tCount = new Dictionary<char, int>();
        foreach (char c in t) {
            tCount[c] = tCount.GetValueOrDefault(c, 0) + 1;
        }
        
        // Variables for sliding window
        int required = tCount.Count; // Number of unique characters in t
        int formed = 0; // Number of unique characters in current window with desired frequency
        
        // Dictionary to count characters in current window
        Dictionary<char, int> windowCount = new Dictionary<char, int>();
        
        // Variables to track the minimum window
        int[] ans = { -1, 0, 0 }; // {length, left, right}
        
        // Sliding window pointers
        int left = 0, right = 0;
        
        while (right < s.Length) {
            // Add character from right
            char c = s[right];
            windowCount[c] = windowCount.GetValueOrDefault(c, 0) + 1;
            
            // Check if this character's frequency matches what we need
            if (tCount.ContainsKey(c) && windowCount[c] == tCount[c]) {
                formed++;
            }
            
            // Try to contract the window from the left
            while (left <= right && formed == required) {
                c = s[left];
                
                // Update minimum window if current is smaller
                if (ans[0] == -1 || right - left + 1 < ans[0]) {
                    ans[0] = right - left + 1;
                    ans[1] = left;
                    ans[2] = right;
                }
                
                // Remove character from left
                windowCount[c]--;
                if (tCount.ContainsKey(c) && windowCount[c] < tCount[c]) {
                    formed--;
                }
                
                left++;
            }
            
            right++;
        }
        
        return ans[0] == -1 ? "" : s.Substring(ans[1], ans[2] - ans[1] + 1);
    }
}