public class Solution {
    public IList<string> BinaryTreePaths(TreeNode root) {
        List<string> result = new List<string>();
        if (root == null) return result;
        DFS(root, "", result);
        return result;
    }
    
    private void DFS(TreeNode node, string path, List<string> result) {
        if (node == null) return;
        
        if (string.IsNullOrEmpty(path)) {
            path = node.val.ToString();
        } else {
            path += "->" + node.val;
        }
        
        if (node.left == null && node.right == null) {
            result.Add(path);
            return;
        }
        
        DFS(node.left, path, result);
        DFS(node.right, path, result);
    }
}