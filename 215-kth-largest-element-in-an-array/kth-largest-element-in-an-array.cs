using System.Collections.Generic;

public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        
        foreach (int num in nums) {
            if (minHeap.Count < k) {
                minHeap.Enqueue(num, num);
            } else {
                if (num > minHeap.Peek()) {
                    minHeap.Dequeue();
                    minHeap.Enqueue(num, num);
                }
            }
        }
        
        return minHeap.Peek();
    }
}