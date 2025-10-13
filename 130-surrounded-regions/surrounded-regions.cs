public class Solution {
    public void Solve(char[][] board) {
        if (board == null || board.Length == 0) return;
        
        int m = board.Length;
        int n = board[0].Length;
        
        // Mark border-connected 'O's with temporary marker 'T'
        // First and last rows
        for (int j = 0; j < n; j++) {
            if (board[0][j] == 'O') DFS(board, 0, j);
            if (board[m-1][j] == 'O') DFS(board, m-1, j);
        }
        
        // First and last columns
        for (int i = 0; i < m; i++) {
            if (board[i][0] == 'O') DFS(board, i, 0);
            if (board[i][n-1] == 'O') DFS(board, i, n-1);
        }
        
        // Process the board
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (board[i][j] == 'O') {
                    board[i][j] = 'X'; // Capture surrounded region
                } else if (board[i][j] == 'T') {
                    board[i][j] = 'O'; // Restore border-connected cells
                }
            }
        }
    }
    
    private void DFS(char[][] board, int i, int j) {
        int m = board.Length;
        int n = board[0].Length;
        
        // Check boundaries and if current cell is 'O'
        if (i < 0 || i >= m || j < 0 || j >= n || board[i][j] != 'O') {
            return;
        }
        
        // Mark as temporary
        board[i][j] = 'T';
        
        // Visit adjacent cells
        DFS(board, i + 1, j);
        DFS(board, i - 1, j);
        DFS(board, i, j + 1);
        DFS(board, i, j - 1);
    }
}