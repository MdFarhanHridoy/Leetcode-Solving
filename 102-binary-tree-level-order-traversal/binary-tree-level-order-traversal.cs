public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        IList<IList<int>> result = new List<IList<int>>();
        if (root == null) return result;
        
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count > 0) {
            int levelSize = queue.Count;
            List<int> currentLevel = new List<int>();
            
            for (int i = 0; i < levelSize; i++) {
                TreeNode currentNode = queue.Dequeue();
                currentLevel.Add(currentNode.val);
                
                if (currentNode.left != null) {
                    queue.Enqueue(currentNode.left);
                }
                if (currentNode.right != null) {
                    queue.Enqueue(currentNode.right);
                }
            }
            
            result.Add(currentLevel);
        }
        
        return result;
    }
}