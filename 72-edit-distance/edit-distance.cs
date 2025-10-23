public class Solution {
    public int MinDistance(string word1, string word2) {
        int m = word1.Length;
        int n = word2.Length;
        
        int[] prev = new int[n + 1];
        int[] curr = new int[n + 1];
        
        // Initialize first row
        for (int j = 0; j <= n; j++) {
            prev[j] = j;
        }
        
        for (int i = 1; i <= m; i++) {
            curr[0] = i; // Deleting i characters from word1
            
            for (int j = 1; j <= n; j++) {
                if (word1[i - 1] == word2[j - 1]) {
                    curr[j] = prev[j - 1];
                } else {
                    curr[j] = 1 + Math.Min(
                        prev[j],        // Delete
                        Math.Min(
                            curr[j - 1], // Insert
                            prev[j - 1]  // Replace
                        )
                    );
                }
            }
            
            // Swap arrays for next iteration
            int[] temp = prev;
            prev = curr;
            curr = temp;
        }
        
        return prev[n];
    }
}