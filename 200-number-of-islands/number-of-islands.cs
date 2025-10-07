public class Solution {
    public int NumIslands(char[][] grid) {
        if (grid == null || grid.Length == 0) return 0;
        
        int numIslands = 0;
        int m = grid.Length;
        int n = grid[0].Length;
        
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (grid[i][j] == '1') {
                    numIslands++;
                    DFS(grid, i, j);
                }
            }
        }
        
        return numIslands;
    }
    
    private void DFS(char[][] grid, int i, int j) {
        int m = grid.Length;
        int n = grid[0].Length;
        
        // Check boundaries and if current cell is land
        if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] == '0') {
            return;
        }
        
        // Mark current cell as visited by setting it to '0'
        grid[i][j] = '0';
        
        // Visit all adjacent cells
        DFS(grid, i + 1, j); // down
        DFS(grid, i - 1, j); // up
        DFS(grid, i, j + 1); // right
        DFS(grid, i, j - 1); // left
    }
}