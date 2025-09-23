public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        while (root != null) {
            int leftCount = CountNodes(root.left);
            
            if (k == leftCount + 1) {
                return root.val;
            } else if (k <= leftCount) {
                root = root.left;
            } else {
                root = root.right;
                k = k - leftCount - 1;
            }
        }
        return -1;
    }
    
    private int CountNodes(TreeNode node) {
        if (node == null) return 0;
        return 1 + CountNodes(node.left) + CountNodes(node.right);
    }
}