public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) {
        int originalColor = image[sr][sc];
        if (originalColor == color) return image;
        
        DFS(image, sr, sc, originalColor, color);
        return image;
    }
    
    private void DFS(int[][] image, int row, int col, int originalColor, int newColor) {
        // Check boundaries
        if (row < 0 || row >= image.Length || col < 0 || col >= image[0].Length) return;
        
        // Check if pixel needs to be filled
        if (image[row][col] != originalColor) return;
        
        // Change the color
        image[row][col] = newColor;
        
        // Recursively fill neighboring pixels
        DFS(image, row + 1, col, originalColor, newColor); // down
        DFS(image, row - 1, col, originalColor, newColor); // up
        DFS(image, row, col + 1, originalColor, newColor); // right
        DFS(image, row, col - 1, originalColor, newColor); // left
    }
}