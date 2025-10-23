public class Solution {
    public int MinDistance(string word1, string word2) {
        int m = word1.Length;
        int n = word2.Length;
        
        int[,] dp = new int[m + 1, n + 1];
        
        // Initialize base cases
        for (int i = 0; i <= m; i++) {
            dp[i, 0] = i; // Deleting all characters from word1
        }
        for (int j = 0; j <= n; j++) {
            dp[0, j] = j; // Inserting all characters into empty string
        }
        
        // Fill DP table
        for (int i = 1; i <= m; i++) {
            for (int j = 1; j <= n; j++) {
                if (word1[i - 1] == word2[j - 1]) {
                    // Characters match, no operation needed
                    dp[i, j] = dp[i - 1, j - 1];
                } else {
                    // Take minimum of three operations and add 1
                    dp[i, j] = 1 + Math.Min(
                        dp[i - 1, j],     // Delete
                        Math.Min(
                            dp[i, j - 1], // Insert
                            dp[i - 1, j - 1] // Replace
                        )
                    );
                }
            }
        }
        
        return dp[m, n];
    }
}