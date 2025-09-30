public class Solution {
    public int OrangesRotting(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        
        Queue<(int, int)> queue = new Queue<(int, int)>();
        int freshCount = 0;
        
        // Initialize the queue with all initially rotten oranges and count fresh oranges
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == 2) {
                    queue.Enqueue((i, j));
                } else if (grid[i][j] == 1) {
                    freshCount++;
                }
            }
        }
        
        // If there are no fresh oranges initially, return 0
        if (freshCount == 0) return 0;
        
        int minutes = 0;
        int[][] directions = new int[][] {
            new int[] {1, 0},    // down
            new int[] {-1, 0},   // up
            new int[] {0, 1},    // right
            new int[] {0, -1}    // left
        };
        
        while (queue.Count > 0) {
            int size = queue.Count;
            bool madeRotten = false;
            
            for (int i = 0; i < size; i++) {
                var (x, y) = queue.Dequeue();
                
                foreach (var dir in directions) {
                    int newX = x + dir[0];
                    int newY = y + dir[1];
                    
                    if (newX >= 0 && newX < m && newY >= 0 && newY < n && grid[newX][newY] == 1) {
                        grid[newX][newY] = 2;
                        queue.Enqueue((newX, newY));
                        freshCount--;
                        madeRotten = true;
                    }
                }
            }
            
            if (madeRotten) minutes++;
        }
        
        return freshCount == 0 ? minutes : -1;
    }
}