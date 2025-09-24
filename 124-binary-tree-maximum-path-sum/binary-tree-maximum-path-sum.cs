public class Solution {
    private int maxSum = int.MinValue;
    
    public int MaxPathSum(TreeNode root) {
        MaxGain(root);
        return maxSum;
    }
    
    private int MaxGain(TreeNode node) {
        if (node == null) return 0;
        
        // Recursively get the maximum gains from left and right subtrees
        int leftGain = Math.Max(MaxGain(node.left), 0);
        int rightGain = Math.Max(MaxGain(node.right), 0);
        
        // The price to start a new path where 'node' is the highest point
        int priceNewPath = node.val + leftGain + rightGain;
        
        // Update the global maximum sum
        maxSum = Math.Max(maxSum, priceNewPath);
        
        // Return the maximum gain if we continue the same path upward
        return node.val + Math.Max(leftGain, rightGain);
    }
}