/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    private Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
    
    public Node CloneGraph(Node node) {
        if (node == null) return null;
        
        // If the node was already visited, return the clone from the visited dictionary
        if (visited.ContainsKey(node)) {
            return visited[node];
        }
        
        // Create a clone for the given node
        Node cloneNode = new Node(node.val);
        visited.Add(node, cloneNode);
        
        // Iterate through the neighbors to generate their clones
        foreach (Node neighbor in node.neighbors) {
            cloneNode.neighbors.Add(CloneGraph(neighbor));
        }
        
        return cloneNode;
    }
}