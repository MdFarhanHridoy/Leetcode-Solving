public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        HashSet<string> wordSet = new HashSet<string>(wordList);
        if (!wordSet.Contains(endWord)) return 0;
        
        Queue<string> queue = new Queue<string>();
        queue.Enqueue(beginWord);
        int level = 1;
        
        while (queue.Count > 0) {
            int levelSize = queue.Count;
            
            for (int i = 0; i < levelSize; i++) {
                string currentWord = queue.Dequeue();
                
                if (currentWord == endWord) {
                    return level;
                }
                
                // Generate all possible neighbors
                char[] wordChars = currentWord.ToCharArray();
                for (int j = 0; j < wordChars.Length; j++) {
                    char originalChar = wordChars[j];
                    
                    for (char c = 'a'; c <= 'z'; c++) {
                        if (c == originalChar) continue;
                        
                        wordChars[j] = c;
                        string newWord = new string(wordChars);
                        
                        if (wordSet.Contains(newWord)) {
                            queue.Enqueue(newWord);
                            wordSet.Remove(newWord); // Mark as visited
                        }
                    }
                    
                    wordChars[j] = originalChar; // Restore original character
                }
            }
            
            level++;
        }
        
        return 0;
    }
}