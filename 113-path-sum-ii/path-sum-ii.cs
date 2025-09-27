public class Solution {
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        List<IList<int>> result = new List<IList<int>>();
        List<int> currentPath = new List<int>();
        DFS(root, targetSum, currentPath, result);
        return result;
    }
    
    private void DFS(TreeNode node, int targetSum, List<int> currentPath, List<IList<int>> result) {
        if (node == null) return;
        
        // Add current node to the path
        currentPath.Add(node.val);
        
        // Check if it's a leaf node and the sum matches target
        if (node.left == null && node.right == null && node.val == targetSum) {
            result.Add(new List<int>(currentPath));
        } else {
            // Recursively check left and right subtrees
            DFS(node.left, targetSum - node.val, currentPath, result);
            DFS(node.right, targetSum - node.val, currentPath, result);
        }
        
        // Backtrack: remove the current node from the path
        currentPath.RemoveAt(currentPath.Count - 1);
    }
}