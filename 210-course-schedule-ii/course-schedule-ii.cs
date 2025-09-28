public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        // Create adjacency list and in-degree array
        List<int>[] graph = new List<int>[numCourses];
        int[] inDegree = new int[numCourses];
        
        for (int i = 0; i < numCourses; i++) {
            graph[i] = new List<int>();
        }
        
        // Build the graph
        foreach (var prereq in prerequisites) {
            int course = prereq[0];
            int prerequisite = prereq[1];
            graph[prerequisite].Add(course);
            inDegree[course]++;
        }
        
        // Queue for courses with no prerequisites
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (inDegree[i] == 0) {
                queue.Enqueue(i);
            }
        }
        
        int[] result = new int[numCourses];
        int index = 0;
        
        // Process courses
        while (queue.Count > 0) {
            int current = queue.Dequeue();
            result[index++] = current;
            
            foreach (int neighbor in graph[current]) {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0) {
                    queue.Enqueue(neighbor);
                }
            }
        }
        
        // If we processed all courses, return result; otherwise, empty array
        return index == numCourses ? result : new int[0];
    }
}